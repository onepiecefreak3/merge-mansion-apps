using System;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Network
{
    public class TlsMessageTransport : TcpMessageTransport
    {
        public TlsMessageTransport(/*LogChannel log,*/ ConfigArgs config) : base(config ?? new TcpMessageTransport.ConfigArgs())
        { }

        public new ConfigArgs Config()
        {
            if (_configBase == null)
                return null;

            if (_configBase is ConfigArgs tlsc)
                return tlsc;

            throw new InvalidOperationException();
        }

        public class ConfigArgs : TcpMessageTransport.ConfigArgs
        { }

        protected override async Task<(Stream, TransportHandshakeReport)> OpenStream(CancellationToken ct)
        {
            var connectionStartedAt = MetaTime.Now;
            var (tcpStream, tcpReport) = await base.OpenStream(ct);

            // Log debug "Authenticating TLS..."

            var callback = new RemoteCertificateValidationCallback(CertificateValidationCallback);
            var sslStream = new SslStream(tcpStream, false, callback, null);

            var authenticateTask = sslStream.AuthenticateAsClientAsync(tcpReport.ChosenHostname);

            var tasks = new[] { authenticateTask, Task.Delay(-1, ct) };
            await Task.WhenAny(tasks);

            if (ct.IsCancellationRequested)
            {
                AbandonConnectionStream(authenticateTask.ContinueWith<Stream>(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                        return sslStream;

                    if (task.IsFaulted && task.Exception != null)
                        throw task.Exception;

                    throw new OperationCanceledException();
                }), connectionStartedAt);
                throw new InvalidOperationException("Task is over!");
            }

            await authenticateTask;

            if (!sslStream.IsEncrypted)
            {
                // Log debug "tls authentication failed. Expected IsEncrypted."

                InvokeOnError(new TlsError(TlsError.ErrorCode.NotEncrypted));
                throw new InvalidOperationException("Task is over!");
            }

            if (sslStream.RemoteCertificate is X509Certificate2 cert)
            {
                var description = string.Concat(cert.Issuer, ", 1.3.6.1.4.1.388.6.3.34.5.1.1.12=", cert.Thumbprint);
                var report = new TransportHandshakeReport(tcpReport.ChosenHostname, tcpReport.ChosenProtocol, description);

                return (sslStream, report);
            }

            throw new InvalidOperationException();
        }

        private bool CertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public class TlsError : Error
        {
            public ErrorCode Error; // 0x10

            public TlsError(ErrorCode error)
            {
                Error = error;
            }

            public enum ErrorCode
            {
                NotAuthenticated = 0,
                FailureWhileAuthenticating = 1,
                NotEncrypted = 2
            }
        }
    }
}
