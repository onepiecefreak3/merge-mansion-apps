using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Metaplay.Core.Message;

namespace Metaplay.Core.Network
{
    public abstract class StreamMessageTransport : WireMessageTransport
    {
        private Task _connectionTask; // 0x38
        private CancellationTokenSource _cts; // 0x40
        private object _outgoingLock; // 0x48
        private List<OutgoingMessage> _outgoingMessages; // 0x50
        private TaskCompletionSource<int> _outgoingMessagesPending; // 0x58
        private bool _closingAfterSendBufferComplete; // 0x60
        private TaskCompletionSource<int> _closingAfterSendBufferCompletePending; // 0x68
        private bool _onConnectedInvoked; // 0x70
        private bool _receivedServerHello; // 0x71
        private TransportHandshakeReport _transportHandshake; // 0x78
        protected readonly ConfigBase _configBase; // 0x90
        protected bool _enableCompression; // 0x98
        private LoginTransportDebugDiagnostics _debugDiagnostics; // 0xA0

        // protected LogChannel Log { get; } // 0x30

        public StreamMessageTransport( /*LogChannel log,*/ ConfigArgs config)
        {
            _outgoingLock = new object();
            _outgoingMessages = new List<OutgoingMessage>();
            _outgoingMessagesPending = new TaskCompletionSource<int>();
            _closingAfterSendBufferCompletePending = new TaskCompletionSource<int>();
            _debugDiagnostics = new LoginTransportDebugDiagnostics();
            _configBase = config;
        }

        public override void SetDebugDiagnosticsRef(LoginTransportDebugDiagnostics debugDiagnostics)
        {
            _debugDiagnostics = debugDiagnostics ?? new LoginTransportDebugDiagnostics();
        }

        public override void Open()
        {
            lock (_outgoingLock)
            {
                if (_cts != null)
                    throw new InvalidOperationException();

                _cts = new CancellationTokenSource();
                _connectionTask = Task.Run(ConnectionTask);
            }
        }

        //public override bool WasClosed()
        //{
        //    if (_connectionTask == null)
        //        return false;

        //    return _connectionTask.Status == TaskStatus.Faulted || _connectionTask.Status == TaskStatus.Canceled;
        //}

        public override void EnqueueSendMessage(MetaMessage message)
        {
            Interlocked.Increment(ref _debugDiagnostics.MetaMessageEnqueuesAttempted);
            if (!_onConnectedInvoked)
            {
                Interlocked.Increment(ref _debugDiagnostics.MetaMessageUnconnectedEnqueuesAttempted);
                // Log warning "Enqueuing message to a transport that has not yet Connected()"
            }
            else
            {
                if (_connectionTask == null)
                {
                    Interlocked.Increment(ref _debugDiagnostics.MetaMessageDisposedEnqueuesAttempted);
                    // Log warning "Enqueuing message to a disposed transport"
                }
            }

            var encodedMessage = EncodeMessage(message, _enableCompression);
            var wasSent = EnqueueSendBytes(encodedMessage, OutgoingMessage.MessageKind.MetaMessage);
            if (wasSent)
            {
                Interlocked.Increment(ref _debugDiagnostics.MetaMessagesEnqueued);
                return;
            }

            Interlocked.Increment(ref _debugDiagnostics.MetaMessageClosingEnqueuesAttempted);
            // Log warning "Enqueuing message to a closing transport"
        }

        public override void Dispose()
        {
            if (_connectionTask == null)
                return;

            _connectionTask = null;
            _cts?.Cancel();
        }

        private async Task ConnectionTask()
        {
            var set = new PollSet();

            var incomingBuffer = new ReadWriteBuffer();
            incomingBuffer.Compact(0x2000);

            var (stream, transportHandshake) = await TryOpenStream(_cts.Token);
            _transportHandshake = transportHandshake;

            var config = Config();

            var headerDelay = Task.Delay(config.HeaderReadTimeout, _cts.Token);

            var clientHello = new Handshake.ClientHello(config.Version, config.BuildNumber, config.SupportedLogicVersions,
                config.FullProtocolHash, config.CommitId, MetaTime.Now, config.AppLaunchId, config.ClientSessionNonce,
                config.ClientSessionConnectionNdx, config.Platform, config.LoginProtocolVersion);
            var clientHelloData = EncodeMessage(clientHello, _enableCompression);
            EnqueueSendBytes(clientHelloData, OutgoingMessage.MessageKind.MetaMessage);

            var receivedProtocolHeader = false;
            Task headerTimeout = null;
            Task writeTimeout = null;
            Task readTimeout = null;
            Task writeKeepaliveTimeout = null;
            Task readKeepaliveTimeout = null;
            Task writeTask = null;
            WriteInfo writeInfo = default;
            Task<int> readTask = null;
            Task writeWarnTimeout = null;
            Task readWarnTimeout = null;
            var pendingReadWarnTimeout = false;
            var pendingWriteWarnTimeout = false;
            do
            {
                if (_onConnectedInvoked)
                    InvokeOnInfo(ThreadCycleUpdateInfo.Instance);

                if (_cts.Token.IsCancellationRequested)
                    throw new InvalidOperationException("Task is over!");

                //CheckTimeoutIfNotNull<HeaderTimeoutError>(headerDelay);
                //CheckTimeoutIfNotNull<ReadTimeoutError>(readTimeout);
                //CheckTimeoutIfNotNull<WriteTimeoutError>(writeTimeout);

                CheckEnqueuedClose(writeTask);

                // Complete write actions
                var wasWritten = TryCompleteWrite(ref writeTask, ref writeInfo, _cts.Token);
                if (wasWritten)
                {
                    writeTimeout = null;
                    if (writeWarnTimeout != null)
                        writeWarnTimeout = null;
                    else
                    {
                        if (pendingWriteWarnTimeout)
                            pendingWriteWarnTimeout = false;
                        else
                            InvokeOnInfo(WriteDurationWarningInfo.ForEnd());
                    }

                    writeKeepaliveTimeout = Task.Delay(config.WriteKeepaliveInterval, _cts.Token);
                }

                // Complete read actions
                var wasRead = TryCompleteRead(ref incomingBuffer, ref readTask, _cts.Token);
                if (wasRead)
                {
                    readTimeout = null;
                    if (readWarnTimeout != null)
                        readWarnTimeout = null;
                    else
                    {
                        if (pendingReadWarnTimeout)
                            pendingReadWarnTimeout = false;
                        else
                            InvokeOnInfo(ReadDurationWarningInfo.ForEnd());
                    }

                    readKeepaliveTimeout = null;

                    // Process header
                    incomingBuffer.Limit = incomingBuffer.Position;
                    incomingBuffer.Position = 0;

                    var i = 0;
                    if (!receivedProtocolHeader)
                    {
                        var headerProcessed = TryProcessProtocolHeader(ref incomingBuffer, out var framedSize, _cts.Token);
                        if (headerProcessed)
                        {
                            receivedProtocolHeader = true;
                            headerTimeout = null;
                            writeKeepaliveTimeout = Task.Delay(config.WriteKeepaliveInterval, _cts.Token);
                        }

                        i = System.Math.Max(0, framedSize);
                    }

                    // Process messages
                    if (receivedProtocolHeader)
                    {
                        bool msgProcessed;
                        do
                        {
                            msgProcessed = TryProcessMessage(ref incomingBuffer, out var framedSize, _cts.Token);
                            i = System.Math.Max(i, framedSize);
                        } while (msgProcessed);
                    }

                    // Resize buffer according to the read messages
                    var bufferLength = incomingBuffer.Array?.Length ?? 0;
                    if (bufferLength < i)
                        bufferLength = System.Math.Max(bufferLength << 1, i);

                    incomingBuffer.Compact(bufferLength);
                }

                // Start write action
                var startedWrite = TryStartWriteTask(stream, ref writeTask, ref writeInfo, _cts.Token);
                if (startedWrite)
                {
                    writeTimeout = Task.Delay(config.WriteTimeout, _cts.Token);
                    writeWarnTimeout = Task.Delay(config.WarnAfterWriteDuration, _cts.Token);
                    pendingWriteWarnTimeout = false;
                    writeKeepaliveTimeout = null;
                }

                // Start read action
                var startedReading = TryStartReadTask(stream, ref incomingBuffer, ref readTask, _cts.Token);
                if (startedReading)
                {
                    readTimeout = Task.Delay(config.ReadTimeout, _cts.Token);
                    readWarnTimeout = Task.Delay(config.WarnAfterReadDuration, _cts.Token);
                    pendingReadWarnTimeout = false;
                    readKeepaliveTimeout = Task.Delay(config.ReadKeepaliveInterval, _cts.Token);
                }

                // Complete keep alive actions
                var keptAlive = TryCompleteKeepalive(ref writeKeepaliveTimeout);
                if (keptAlive)
                {
                    writeKeepaliveTimeout = Task.Delay(config.WriteKeepaliveInterval, _cts.Token);
                    readKeepaliveTimeout = null;
                }

                keptAlive = TryCompleteKeepalive(ref readKeepaliveTimeout);
                if (keptAlive)
                {
                    readKeepaliveTimeout = Task.Delay(config.ReadKeepaliveInterval, _cts.Token);
                    if (writeKeepaliveTimeout != null)
                        writeKeepaliveTimeout = Task.Delay(config.WriteKeepaliveInterval, _cts.Token);
                }

                // Consume timeouts
                var consumed = TryConsumeTimeoutIfNotNull(ref writeWarnTimeout);
                if (consumed)
                    pendingWriteWarnTimeout = true;

                consumed = TryConsumeTimeoutIfNotNull(ref readWarnTimeout);
                if (consumed)
                    pendingReadWarnTimeout = true;
                if (pendingReadWarnTimeout)
                {
                    if (_onConnectedInvoked)
                    {
                        InvokeOnInfo(ReadDurationWarningInfo.ForBegin());
                        pendingReadWarnTimeout = false;
                    }
                }

                if (pendingWriteWarnTimeout && _onConnectedInvoked)
                {
                    InvokeOnInfo(WriteDurationWarningInfo.ForBegin());
                    pendingWriteWarnTimeout = false;
                }

                // Process poll set
                set.AddIfNotNull(headerTimeout);
                set.AddIfNotNull(readTimeout);
                set.AddIfNotNull(writeTimeout);
                set.AddIfNotNull(readTask);
                set.AddIfNotNull(writeTask);
                if (writeInfo.NumMetaMessages == 0)
                {
                    set.AddIfNotNull(_outgoingMessagesPending.Task);
                    set.AddIfNotNull(_closingAfterSendBufferCompletePending.Task);
                }
                set.AddIfNotNull(writeKeepaliveTimeout);
                set.AddIfNotNull(readKeepaliveTimeout);
                set.AddIfNotNull(readWarnTimeout);
                set.AddIfNotNull(writeWarnTimeout);
                set.AddIfNotNull(Task.Delay(5000, _cts.Token));

                await Task.WhenAny(set.Tasks);
                set.Reset();
            } while (true);

            // case 2 and 3? They implement logic and dispose variables, but are never reached
        }

        private async Task<(Stream, TransportHandshakeReport)> TryOpenStream(CancellationToken ct)
        {
            var connectionStartedAt = MetaTime.Now;

            var config = Config();
            var openTask = OpenStream(ct);
            var closeTask = _closingAfterSendBufferCompletePending.Task;
            var anyTask = await Task.WhenAny(openTask, _closingAfterSendBufferCompletePending.Task, Task.Delay(config.ConnectTimeout, ct));

            if (ct.IsCancellationRequested)
            {
                AbandonConnectionStream(openTask, connectionStartedAt);
                throw new InvalidOperationException("Task is over!");
            }

            if (anyTask == closeTask)
            {
                AbandonConnectionStream(openTask, connectionStartedAt);
                InvokeOnError(new EnqueuedCloseError());
            }

            if (anyTask != openTask)
            {
                AbandonConnectionStream(openTask, connectionStartedAt);

                InvokeOnError(new ConnectTimeoutError());
                throw new InvalidOperationException("Task is over!");
            }

            return await openTask;
        }

        protected void AbandonConnectionStream(Task<(Stream, TransportHandshakeReport)> streamTask, MetaTime connectionStartedAt)
        {
            var continueTask = streamTask.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    return task.Result.Item1;

                if (task.IsFaulted && task.Exception != null)
                    throw task.Exception;

                throw new InvalidOperationException("Task is over!");
            });

            AbandonConnectionStream(continueTask, connectionStartedAt);
        }

        protected void AbandonConnectionStream(Task<Stream> streamTask, MetaTime connectionStartedAt)
        {
            var abandonAt = MetaTime.Now;

            streamTask.ContinueWith(async task =>
            {
                if (task.Status != TaskStatus.RanToCompletion)
                {
                    if (task.IsFaulted && task.Exception != null)
                        throw task.Exception;

                    return;
                }

                await using var res = task.Result;

                var abandonReq = new Handshake.ClientAbandon(connectionStartedAt, abandonAt, MetaTime.Now, Handshake.ClientAbandon.AbandonSource.PrimaryConnection);
                var encodedAbandonReq = EncodeMessage(abandonReq, _enableCompression);

                await res.WriteAsync(encodedAbandonReq, 0, encodedAbandonReq.Length);
            });
        }

        protected abstract Task<(Stream, TransportHandshakeReport)> OpenStream(CancellationToken ct);

        private bool EnqueueSendBytes(byte[] buffer, OutgoingMessage.MessageKind kind)
        {
            Interlocked.Increment(ref _debugDiagnostics.PacketEnqueuesAttempted);

            lock (_outgoingLock)
            {
                if (_closingAfterSendBufferComplete)
                    return false;

                _outgoingMessages.Add(new OutgoingMessage(buffer, kind));
                _outgoingMessagesPending.TrySetResult(0);

                Interlocked.Increment(ref _debugDiagnostics.PacketsEnqueued);

                Interlocked.Add(ref _debugDiagnostics.BytesEnqueued, buffer.Length);
            }

            return true;
        }

        public ConfigArgs Config()
        {
            if (_configBase == null)
                return null;

            if (_configBase is ConfigArgs configArgs)
                return configArgs;

            throw new InvalidOperationException("Invalid config type.");
        }

        private void CheckTimeoutIfNotNull<ErrorT>(Task timeoutTask)
            where ErrorT : Error, new()
        {
            if (timeoutTask == null || timeoutTask.Status != TaskStatus.RanToCompletion)
                return;

            InvokeOnError(new ErrorT());
            throw new InvalidOperationException("Task is over!");
        }

        private void CheckEnqueuedClose(Task ongoingWriteTask)
        {
            if (ongoingWriteTask != null || !_closingAfterSendBufferComplete)
                return;

            lock (_outgoingLock)
            {
                if (_outgoingMessages.Count > 0)
                {
                    InvokeOnError(new EnqueuedCloseError());
                    throw new InvalidOperationException("Task is over!");
                }
            }
        }

        private bool TryCompleteWrite(ref Task writeTask, ref WriteInfo writeInfo, CancellationToken ct)
        {
            if (writeTask == null)
                return false;

            if (writeTask.Status != TaskStatus.RanToCompletion)
            {
                if (writeTask.Status == TaskStatus.Faulted)
                    throw new InvalidOperationException("Task is over!");

                if (writeTask.Status != TaskStatus.Canceled)
                    return false;

                if (!ct.IsCancellationRequested)
                {
                    // Log debug 'message transport closing due to write error: {writeTask.Exception}'

                    InvokeOnError(new StreamIOFailedError(StreamIOFailedError.OpType.Write, writeTask.Exception));
                }

                throw new InvalidOperationException("Task is over!");
            }

            writeTask.Dispose();
            writeTask = null;

            Interlocked.Increment(ref _debugDiagnostics.WritesCompleted);
            Interlocked.Add(ref _debugDiagnostics.MetaMessagesWritten, writeInfo.NumMetaMessages);
            Interlocked.Add(ref _debugDiagnostics.PacketsWritten, writeInfo.NumPackets);
            Interlocked.Add(ref _debugDiagnostics.BytesWritten, writeInfo.NumBytes);

            writeInfo = default;

            return true;
        }

        private bool TryCompleteRead(ref ReadWriteBuffer buffer, ref Task<int> readTask, CancellationToken ct)
        {
            if (readTask == null)
                return false;

            if (readTask.Status == TaskStatus.RanToCompletion)
            {
                var result = readTask.Result;

                readTask.Dispose();
                readTask = null;

                if (result == 0)
                {
                    InvokeOnError(new StreamClosedError());
                    throw new InvalidOperationException("Task is over!");
                }

                buffer.Position += result;

                Interlocked.Increment(ref _debugDiagnostics.ReadsCompleted);
                Interlocked.Add(ref _debugDiagnostics.BytesRead, result);

                return true;
            }

            if (readTask.Status == TaskStatus.Canceled)
                throw new InvalidOperationException("Task is over!");

            if (readTask.Status == TaskStatus.Faulted)
            {
                if (ct.IsCancellationRequested)
                    throw new InvalidOperationException("Task is over!");

                // Log debug 'message transport closing due to read error: {readTask.Exception}'

                InvokeOnError(new StreamIOFailedError(StreamIOFailedError.OpType.Read, readTask.Exception));
                throw new InvalidOperationException("Task is over!");
            }

            return false;
        }

        private bool TryProcessMessage(ref ReadWriteBuffer buffer, out int framedSize, CancellationToken ct)
        {
            framedSize = 4;

            if (buffer.Limit - buffer.Position < 4)
                return false;

            var header = WireProtocol.DecodePacketHeader(buffer.Array, buffer.Position, false);

            framedSize = buffer.Position + 4;

            if (buffer.Limit - buffer.Position < framedSize)
                return false;

            byte[] dataBuffer;
            int dataStart;
            int dataLength;
            if (header.Compression == WirePacketCompression.Deflate)
            {
                var start = buffer.Position + 4;
                dataBuffer = CompressUtil.DeflateDecompress(buffer.Array, start, buffer.Limit - start);

                dataLength = dataBuffer.Length;
                dataStart = 0;
            }
            else
            {
                if (header.Compression != WirePacketCompression.None)
                    throw new InvalidOperationException($"Invalid CompressionMode in packet: {header.Compression}");

                dataBuffer = buffer.Array;
                dataStart = buffer.Position + 4;
                dataLength = buffer.Limit - dataStart;
            }

            Interlocked.Increment(ref _debugDiagnostics.PacketsRead);

            if (header.Type == WirePacketType.PingResponse)
            {
                buffer.Position += 4;
                return true;
            }

            if (header.Type == WirePacketType.Ping)
            {
                EnqueueSendPong(dataBuffer, dataStart, dataLength);
                buffer.Position = dataStart + dataLength;
                return true;
            }

            if (header.Type == WirePacketType.Message)
            {
                var msg = WireProtocol.DecodeMessage(dataBuffer, dataStart, dataLength, null);
                buffer.Position = dataStart + dataLength;

                Interlocked.Increment(ref _debugDiagnostics.MetaMessagesRead);

                if (_receivedServerHello)
                {
                    if (msg != null && msg is Handshake.ClientHelloAccepted cha)
                        _enableCompression = cha.ServerOptions.EnableWireCompression;

                    InvokeOnReceive(msg);

                    Interlocked.Increment(ref _debugDiagnostics.MetaMessagesReceived);

                    if (!ct.IsCancellationRequested)
                        return true;
                }
                else
                {
                    if (msg != null && msg is Handshake.ServerHello serverHello)
                    {
                        _onConnectedInvoked = true;
                        _receivedServerHello = true;

                        InvokeOnConnect(serverHello, _transportHandshake);
                        InvokeOnInfo(ThreadCycleUpdateInfo.Instance);

                        Interlocked.Increment(ref _debugDiagnostics.MetaMessagesReceived);

                        if (!ct.IsCancellationRequested)
                            return true;
                    }
                    else
                        InvokeOnError(new MissingHelloError());
                }
            }
            else
                InvokeOnError(new WireFormatError(new Exception($"unrecognized WirePacketType: {header.Type}")));

            throw new InvalidOperationException("Task is over!");
        }

        private bool TryProcessProtocolHeader(ref ReadWriteBuffer buffer, out int framedSize, CancellationToken ct)
        {
            framedSize = 8;

            var bufferPosition = buffer.Position;
            if (buffer.Limit - bufferPosition < 8)
                return false;

            var config = Config();
            var status = WireProtocol.ParseProtocolHeader(buffer.Array, bufferPosition, config.GameMagic);
            buffer.Position += 8;

            if (status == ProtocolStatus.ClusterRunning)
                return true;

            Error error;
            switch (status)
            {
                case ProtocolStatus.WireProtocolVersionMismatch:
                    error = new WireProtocolVersionMismatch(buffer.Array[bufferPosition + 4]);
                    break;

                case ProtocolStatus.InvalidGameMagic:
                    error = new InvalidGameMagic(BinaryPrimitives.ReadUInt32BigEndian(buffer.Array[bufferPosition..]));
                    break;

                default:
                    error = new ProtocolStatusError(status);
                    break;
            }

            InvokeOnError(error);
            throw new InvalidOperationException("Task is over!");
        }

        private bool TryStartWriteTask(Stream stream, ref Task writeTask, ref WriteInfo writeInfo, CancellationToken ct)
        {
            if (writeTask != null)
                return false;

            byte[] buffer;
            int numPackets;
            int numMsgs;
            List<TaskCompletionSource<int>> completions;

            lock (_outgoingLock)
            {
                ConcatBuffers(_outgoingMessages, out buffer, out numPackets, out numMsgs, out completions);

                _outgoingMessages.Clear();
                _outgoingMessagesPending = new TaskCompletionSource<int>();
            }

            if (buffer == null)
                return false;

            Interlocked.Increment(ref _debugDiagnostics.WritesStarted);
            writeTask = stream.WriteAsync(buffer, 0, buffer.Length, ct);
            writeInfo = new WriteInfo { NumMetaMessages = numMsgs, NumPackets = numPackets, NumBytes = buffer.Length };

            if (completions == null)
                return true;

            foreach (var completion in completions)
                writeTask.ContinueWith(task => completion.TrySetResult(0), ct);

            return true;
        }

        private bool TryStartReadTask(Stream stream, ref ReadWriteBuffer buffer, ref Task<int> readTask, CancellationToken ct)
        {
            if (readTask != null)
                return false;

            Interlocked.Increment(ref _debugDiagnostics.ReadsStarted);
            readTask = stream.ReadAsync(buffer.Array, buffer.Position, buffer.Limit - buffer.Position, ct);

            return true;
        }

        private bool TryCompleteKeepalive(ref Task keepaliveTask)
        {
            var wasConsumed = TryConsumeTimeoutIfNotNull(ref keepaliveTask);
            if (wasConsumed)
                EnqueueSendPing32(1);

            return wasConsumed;
        }

        private bool TryConsumeTimeoutIfNotNull(ref Task task)
        {
            if (task == null)
                return false;

            var ranToCompletion = task.Status == TaskStatus.RanToCompletion;
            if (!ranToCompletion && task.Status != TaskStatus.Canceled && task.Status != TaskStatus.Faulted)
                return false;

            task.Dispose();
            task = null;

            return ranToCompletion;
        }

        private void EnqueueSendPing32(uint payload)
        {
            var buffer = new byte[WireProtocol.ProtocolHeaderSize];

            var header = new WirePacketHeader(WirePacketType.Ping, WirePacketCompression.None, WireProtocol.PacketHeaderSize);
            WireProtocol.EncodePacketHeader(header, buffer);

            BinaryPrimitives.WriteUInt32BigEndian(buffer, payload);
        }

        private void EnqueueSendPong(byte[] payloadArray, int payloadOffset, int payloadSize)
        {

        }

        private static void ConcatBuffers(List<OutgoingMessage> messages, out byte[] buffer, out int numPackets, out int numMetaMessages, out List<TaskCompletionSource<int>> completionFences)
        {
            buffer = null;
            numPackets = 0;
            numMetaMessages = 0;
            completionFences = null;

            var totalBufferLength = 0;
            var fenceIndex = 0;

            if (messages.Count >= 1)
            {
                for (var i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Kind == OutgoingMessage.MessageKind.MetaMessage)
                        numMetaMessages++;

                    if (messages[i].Buffer != null)
                        numPackets++;

                    totalBufferLength += messages[i].Buffer?.Length ?? 0;
                }

                for (var i = 0; i < messages.Count; i++)
                {
                    fenceIndex = i;
                    if (messages[i].Kind != OutgoingMessage.MessageKind.Fence)
                        break;
                }
            }

            if (totalBufferLength == 0)
                return;

            buffer = new byte[totalBufferLength];
            if (fenceIndex >= messages.Count)
                return;

            var bufferOffset = 0;
            for (var i = fenceIndex; i < messages.Count; i++)
            {
                if (messages[i].Buffer != null)
                {
                    Buffer.BlockCopy(messages[i].Buffer, 0, buffer, bufferOffset, messages[i].Buffer.Length);
                    bufferOffset += messages[i].Buffer.Length;
                }

                if (messages[i].FenceCS != null)
                {
                    completionFences ??= new List<TaskCompletionSource<int>>();
                    completionFences.Add(messages[i].FenceCS);
                }
            }
        }

        private struct ReadWriteBuffer
        {
            public byte[] Array; // 0x0
            public int Limit; // 0x8
            public int Position; // 0xC

            public void Compact(int capacity)
            {
                if (Array == null)
                    Array = new byte[capacity];
                else
                {
                    if (Array.Length == capacity)
                    {
                        if (Position > 0 && Limit - Position > 0)
                            Buffer.BlockCopy(Array, Position, Array, 0, Limit - Position);
                    }
                    else
                    {
                        var newBuffer = new byte[capacity];
                        if (Limit - Position > 0)
                            Buffer.BlockCopy(Array, Position, newBuffer, 0, Limit - Position);

                        Array = newBuffer;
                    }
                }

                Position = Limit - Position;
                Limit = Array.Length;
            }
        }

        private struct WriteInfo
        {
            public int NumMetaMessages; // 0x0
            public int NumPackets; // 0x4
            public int NumBytes; // 0x8
        }

        public class ConfigArgs : ConfigBase
        {
            public string GameMagic; // 0x10
            public string Version; // 0x18
            public string BuildNumber; // 0x20
            public MetaVersionRange SupportedLogicVersions; // 0x28
            public uint FullProtocolHash; // 0x30
            public string CommitId; // 0x38
            public uint ClientSessionConnectionNdx; // 0x40
            public uint ClientSessionNonce; // 0x44
            public uint AppLaunchId; // 0x48
            public ClientPlatform Platform; // 0x4C
            public int LoginProtocolVersion; // 0x50
            public TimeSpan ConnectTimeout; // 0x58
            public TimeSpan HeaderReadTimeout; // 0x60
            public TimeSpan ReadTimeout; // 0x68
            public TimeSpan WriteTimeout; // 0x70
            public TimeSpan WriteKeepaliveInterval; // 0x78
            public TimeSpan ReadKeepaliveInterval; // 0x80
            public TimeSpan WarnAfterWriteDuration; // 0x88
            public TimeSpan WarnAfterReadDuration; // 0x90
        }

        public class ConfigBase
        {
        }

        private struct OutgoingMessage
        {
            public byte[] Buffer; // 0x0
            public MessageKind Kind; // 0x8
            public TaskCompletionSource<int> FenceCS; // 0x10

            public OutgoingMessage(byte[] buffer, MessageKind kind)
            {
                Buffer = buffer;
                Kind = kind;
                FenceCS = null;
            }

            public OutgoingMessage(TaskCompletionSource<int> fenceCS)
            {
                Buffer = null;
                Kind = MessageKind.Fence;
                FenceCS = fenceCS;
            }

            public enum MessageKind
            {
                MetaMessage = 0,
                Ping = 1,
                Pong = 2,
                Fence = 3
            }
        }

        public class ReadDurationWarningInfo : Info
        {
            public bool IsEnd { get; } // 0x10
            public bool IsBegin => !IsEnd;

            private ReadDurationWarningInfo(bool isEnd)
            {
                IsEnd = isEnd;
            }

            public static ReadDurationWarningInfo ForBegin()
            {
                return new ReadDurationWarningInfo(false);
            }

            public static ReadDurationWarningInfo ForEnd()
            {
                return new ReadDurationWarningInfo(true);
            }
        }

        public class WriteDurationWarningInfo : Info
        {
            public bool IsEnd { get; } // 0x10
            public bool IsBegin => !IsEnd;

            private WriteDurationWarningInfo(bool isEnd)
            {
                IsEnd = isEnd;
            }

            public static WriteDurationWarningInfo ForBegin()
            {
                return new WriteDurationWarningInfo(false);
            }

            public static WriteDurationWarningInfo ForEnd()
            {
                return new WriteDurationWarningInfo(true);
            }
        }

        public class StreamClosedError : Error
        {
        }

        public class StreamIOFailedError : Error
        {
            public readonly OpType Op; // 0x10
            public readonly Exception Exception; // 0x18

            public StreamIOFailedError(OpType op, Exception ex)
            {
                Op = op;
                Exception = ex;
            }

            public enum OpType
            {
                Read = 0,
                Write = 1,
            }
        }

        public class StreamExecutorError : Error
        {
            public readonly Exception Exception; // 0x10

            public StreamExecutorError(Exception ex)
            {
                Exception = ex;
            }
        }
    }
}
