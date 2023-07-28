using System;
using System.Buffers.Binary;
using System.IO;
using Metaplay.Core;
using Metaplay.Core.IO;

namespace Metaplay.Unity
{
    public static class AtomicBlobStore
    {
        public static byte[] TryReadBlob(string path)
        {
            var wasRead = TryReadEnvelopeFromFile(path, out var envelope);
            if (wasRead)
                return envelope;

            wasRead = TryReadEnvelopeFromFile(string.Concat(path, ".old"), out envelope);
            return wasRead ? envelope : null;
        }

        private static bool TryReadEnvelopeFromFile(string path, out byte[] envelopePayload)
        {
            // CUSTOM: Check if file exists. It's unknown how the game checks this path before opening without running into an exception
            envelopePayload = null;
            if (!File.Exists(path))
                return false;

            var data = File.ReadAllBytes(path);
            return TryUnwrapEnvelope(data, out envelopePayload);
        }

        private static bool TryUnwrapEnvelope(byte[] envelope, out byte[] payload)
        {
            using var reader = new IOReader(envelope);

            // Read header
            var buffer = new byte[4];
            reader.ReadBytes(buffer);

            if (BinaryPrimitives.ReadInt32BigEndian(buffer) != 0x48454144)
                throw new InvalidOperationException("Invalid header");

            // Read version
            var version = reader.ReadInt32();
            if (version != 1)
                throw new InvalidOperationException("Invalid version");

            // Read data
            var data = reader.ReadInt32();
            payload = new byte[data];
            reader.ReadBytes(payload);

            // Compare hash
            var readHash = (uint)reader.ReadInt32();
            var computedHash = MurmurHash.MurmurHash2(payload);
            if (readHash != computedHash)
                throw new InvalidOperationException("Invalid hash");

            // Read tail
            buffer = new byte[4];
            reader.ReadBytes(buffer);

            if (BinaryPrimitives.ReadInt32BigEndian(buffer) != 0x5441494C)
                throw new InvalidOperationException("Invalid tail");

            if (reader.Offset != envelope.Length)
                throw new InvalidOperationException("Could not properly unwrap envelope");

            return true;
        }

        public static bool TryWriteBlob(string path, byte[] blob)
        {
            var newPath = string.Concat(path, ".new");

            var wasWritten = TryWriteEnvelope(newPath, blob);
            if (!wasWritten)
                return false;

            var oldPath = string.Concat(path, ".old");
            if (File.Exists(path))
            {
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                File.Move(path, oldPath);
            }

            File.Move(newPath, path);
            File.Delete(oldPath);

            return true;
        }

        public static bool TryDeleteBlob(string path)
        {
            var lck = FileAccessLock.AcquireSync(path);
            if (File.Exists(path))
                File.Delete(path);

            if (File.Exists(path + ".old"))
                File.Delete(path + ".old");

            lck.Dispose();
            return true;
        }

        private static bool TryWriteEnvelope(string path, byte[] envelopePayload)
        {
            var data = WrapEnvelope(envelopePayload);
            File.WriteAllBytes(path, data);

            return true;
        }

        private static byte[] WrapEnvelope(byte[] payload)
        {
            var payloadHash = MurmurHash.MurmurHash2(payload);
            using var writer = new IOWriter();

            // Write header
            var buffer = new byte[] { 0x48, 0x45, 0x41, 0x44 };
            writer.WriteBytes(buffer, 0, 4);

            // Write version
            writer.WriteUInt32(1);

            // Write payload
            writer.WriteUInt32((uint)payload.Length);
            writer.WriteBytes(payload, 0, payload.Length);

            // Write hash
            writer.WriteUInt32(payloadHash);

            // Write tail
            buffer = new byte[] { 0x54, 0x41, 0x49, 0x4C };
            writer.WriteBytes(buffer, 0, 4);

            return writer.ConvertToStream().ToArray();
        }
    }
}
