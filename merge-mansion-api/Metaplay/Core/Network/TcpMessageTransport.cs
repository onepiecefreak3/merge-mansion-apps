using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Network
{
    public class TcpMessageTransport : StreamMessageTransport
    {
        public TcpMessageTransport(/*LogChannel log, */ConfigArgs config) : base(config ?? new ConfigArgs())
        { }

        public new ConfigArgs Config()
        {
            if (_configBase == null)
                return null;

            if (_configBase is ConfigArgs tcpc)
                return tcpc;

            throw new InvalidOperationException();
        }

        protected override async Task<ValueTuple<Stream, TransportHandshakeReport>> OpenStream(CancellationToken ct)
        {
            try
            {
                var config = Config();
                var connectTask4 = config.ServerHostIPv4 == null ?
                    Task.FromException<Stream>(new NoAddressException()) :
                    TryOpenConnectionAsync(config.ServerHostIPv4, config.ServerPort, AddressFamily.InterNetwork, ct);
                var shouldLogError4 = config.ServerHostIPv4 != null;

                await Task.WhenAny(connectTask4, Task.Delay(config.IPv4HeadStartMilliseconds, ct));

                if (ct.IsCancellationRequested)
                    throw new OperationCanceledException();

                if (connectTask4.Status == TaskStatus.RanToCompletion)
                {
                    var report = new TransportHandshakeReport(config.ServerHostIPv4, AddressFamily.InterNetwork, "tcp");
                    return (connectTask4.Result, report);
                }

                // Log debug "IPv4 connect did not complete during the head-start, adding IPv6 to the race"

                var connectTask6 = config.ServerHostIPv6 == null ?
                    Task.FromException<Stream>(new NoAddressException()) :
                    TryOpenConnectionAsync(config.ServerHostIPv6, config.ServerPort, AddressFamily.InterNetworkV6, ct);
                var shouldLogError6 = config.ServerHostIPv6 != null;

                var ctTriggerTask = Task.Delay(-1, ct);
                TaskStatus status = 0;
                do
                {
                    var list = new List<Task>();

                    if (connectTask4.Status == TaskStatus.Faulted)
                    {
                        if (shouldLogError4)
                            ; // Log debug "v4 connection failed with error {connectTask4.Exception}"
                    }
                    else
                        list.Add(connectTask4);

                    if (connectTask6.Status == TaskStatus.Faulted)
                    {
                        if (shouldLogError6)
                            ; // Log debug "v6 connection failed with error {connectTask6.Exception}"
                    }
                    else
                        list.Add(connectTask6);

                    list.Add(ctTriggerTask);

                    if (list.Count == 1)
                    {
                        // HINT: I'm not sure if this is how it should go. Looks weird.
                        connectTask4.ContinueWithDispose();
                        connectTask6.ContinueWithDispose();

                        Error error;
                        if (connectTask4.Exception?.InnerException is TcpRejectedException)
                            error = new ConnectionRefused();
                        else
                        {
                            if (connectTask6.Exception?.InnerException is TcpRejectedException)
                                error = new ConnectionRefused();
                            else
                                error = new CouldNotConnectError();
                        }

                        InvokeOnError(error);
                        throw new InvalidOperationException("Task is over!");
                    }

                    await Task.WhenAny(list);

                    if (ct.IsCancellationRequested)
                    {
                        connectTask4.ContinueWithDispose();
                        connectTask6.ContinueWithDispose();

                        throw new OperationCanceledException();
                    }

                    if (connectTask4.Status == TaskStatus.RanToCompletion)
                    {
                        connectTask6.ContinueWithDispose();

                        var report1 = new TransportHandshakeReport(config.ServerHostIPv4, AddressFamily.InterNetwork, "tcp");
                        return (connectTask4.Result, report1);
                    }

                    status = connectTask6.Status;
                } while (status != TaskStatus.RanToCompletion);

                connectTask4.ContinueWithDispose();

                var report2 = new TransportHandshakeReport(config.ServerHostIPv6, AddressFamily.InterNetworkV6, "tcp");
                return (connectTask6.Result, report2);
            }
            catch (Exception e)
            {
                ;
                throw e;
            }
        }

        private async Task<Stream> TryOpenConnectionAsync(string hostname, int port, AddressFamily af, CancellationToken ct)
        {
            var config = Config();

            var hostAddresses = await DnsCache.GetHostAddressesAsync(hostname, af, config.DnsCacheMaxTTL);
            var socket = new Socket(af, SocketType.Stream, ProtocolType.Tcp);

            var gotAddress = false;
            var gotRejected = false;
            foreach (var hostAddress in hostAddresses)
            {
                ct.ThrowIfCancellationRequested();

                gotAddress = true;

                var endPoint = new IPEndPoint(hostAddress, port);

                // Connect socket
                var connectTask = socket.ConnectAsync(endPoint);
                if (connectTask.IsFaulted && connectTask.Exception != null)
                    continue;

                await connectTask.ConfigureAwait(false);

                if (socket.Connected)
                    return new NetworkStream(socket, true);

                // Log debug "tcp open completed with rejection: {af}"
                gotRejected = true;
            }

            if (gotRejected)
                throw new TcpRejectedException();

            if (gotAddress)
                throw new CannotConnectException();

            throw new NoAddressException();
        }

        public class ConfigArgs : StreamMessageTransport.ConfigArgs
        {
            public string ServerHostIPv4; // 0x98
            public string ServerHostIPv6; // 0xA0
            public int ServerPort; // 0xA8
            public int IPv4HeadStartMilliseconds; // 0xAC
            public TimeSpan DnsCacheMaxTTL; // 0xB0
        }

        private class NoAddressException : Exception
        { }

        private class TcpRejectedException : Exception
        { }

        private class CannotConnectException : Exception
        { }

        public class CouldNotConnectError : Error
        {
        }

        public class ConnectionRefused : TimeoutError
        {
        }
    }
}
