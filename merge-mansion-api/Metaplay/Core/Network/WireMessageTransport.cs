using System;
using System.Linq;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Network
{
    public abstract class WireMessageTransport : MessageTransport
    {
        protected byte[] EncodeMessage(MetaMessage message, bool enableCompression)
        {
            var serialized = MetaSerialization.SerializeTagged(message, MetaSerializationFlags.IncludeAll, null, null);

            var originalLength = serialized.Length;
            if (originalLength <= WireProtocol.MaxPacketUncompressedPayloadSize)
            {
                var compType = WirePacketCompression.None;
                if (originalLength >= WireProtocol.CompressionThresholdBytes && enableCompression)
                {
                    serialized = CompressUtil.DeflateCompress(serialized);
                    compType = WirePacketCompression.Deflate;
                }

                if (serialized.Length <= WireProtocol.MaxPacketWirePayloadSize)
                {
                    var buffer = new byte[serialized.Length + 4];

                    var header = new WirePacketHeader(WirePacketType.Message, compType, serialized.Length);
                    WireProtocol.EncodePacketHeader(header, buffer);

                    Buffer.BlockCopy(serialized, 0, buffer, 4, serialized.Length);

                    return buffer;
                }

                throw new InvalidOperationException($"Maximum packet on-wire size exceeded for {message.GetType().Name} (size={serialized.Length}, uncompressedSize={originalLength}, max={WireProtocol.MaxPacketWirePayloadSize}, uncompressedMax={WireProtocol.MaxPacketUncompressedPayloadSize})");
            }

            throw new InvalidOperationException($"Maximum packet uncompressed size exceeded for {message.GetType().Name} (size={serialized.Length}, max={WireProtocol.MaxPacketUncompressedPayloadSize})");
        }

        protected class PollSet
        {
            private Task[] _tasks; // 0x10
            private int _count; // 0x18

            public ArraySegment<Task> Tasks => new ArraySegment<Task>(_tasks, 0, _count);

            public PollSet()
            {
                _tasks = new Task[0];
            }

            public void AddIfNotNull(Task t)
            {
                if (t == null)
                    return;

                if (_tasks.Length <= _count)
                {
                    var maxCount = System.Math.Max(_count + 1, _tasks.Length << 1);
                    var newTasks = new Task[maxCount];
                    if (_count >= 1)
                        for (var i = 0; i < _tasks.Length; i++)
                            newTasks[i] = _tasks[i];

                    _tasks = newTasks;
                }

                _tasks[_count] = t;
                _count++;
            }

            public void Reset()
            {
                if (_count > 0)
                {
                    for (var i = 0; i < _count; i++)
                        _tasks[i] = null;
                }

                _count = 0;
            }
        }

        public class ProtocolStatusError : Error
        {
            public ProtocolStatus status; // 0x10

            public ProtocolStatusError(ProtocolStatus s)
            {
                status = s;
            }
        }

        public class MissingHelloError : Error
        {
        }

        public class WireFormatError : Error
        {
            public Exception DecodeException; // 0x10

            public WireFormatError(Exception ex)
            {
                DecodeException = ex;
            }
        }

        public class WireProtocolVersionMismatch : Error
        {
            public int ServerProtocolVersion; // 0x10

            public WireProtocolVersionMismatch(int serverProtocolVersion)
            {
                ServerProtocolVersion = serverProtocolVersion;
            }
        }

        public class InvalidGameMagic : Error
        {
            public uint Magic; // 0x10

            public InvalidGameMagic(uint magic)
            {
                Magic = magic;
            }
        }

        public class TimeoutError : Error
        {
        }

        public class ConnectTimeoutError : TimeoutError
        {
        }

        public class HeaderTimeoutError : TimeoutError
        {
        }

        public class ReadTimeoutError : TimeoutError
        {
        }

        public class WriteTimeoutError : TimeoutError
        {
        }

        public class ThreadCycleUpdateInfo : Info
        {
            public static readonly ThreadCycleUpdateInfo Instance = new ThreadCycleUpdateInfo(); // 0x0
        }
    }
}
