using System;
using System.Security.Cryptography;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core
{
    public struct ContentHash : IEquatable<ContentHash>
    {
        // 0x0
        public static readonly ContentHash None = new ContentHash(UInt128.Zero);

        // 0x0
        [MetaMember(1)]
        public UInt128 Value { get; set; }

        public bool IsValid => Value != UInt128.Zero;

        public ContentHash(UInt128 value)
        {
            Value = value;
        }

        public static bool operator ==(ContentHash a, ContentHash b) => a.Value == b.Value;
        public static bool operator !=(ContentHash a, ContentHash b) => a.Value != b.Value;

        public override bool Equals(object obj)
        {
            if (!(obj is ContentHash v))
                return false;

            return this == v;
        }

        public bool Equals(ContentHash other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Value.High:X16}-{Value.Low:X16}";
        }

        public static ContentHash ParseString(string str)
        {
            if (str == null)
                return None;

            var parts = str.Split('-');
            if (parts.Length != 2 || parts[0].Length != 0x10 || parts[1].Length != 0x10)
                throw new ArgumentException($"Invalid hash string '{str}'");

            var p1 = Convert.ToUInt64(parts[0], 16);
            var p2 = Convert.ToUInt64(parts[1], 16);

            return new ContentHash(new UInt128(p1, p2));
        }

        public static bool TryParseString(string str, out ContentHash contentHash)
        {
            contentHash = default;

            try
            {
                contentHash = ParseString(str);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static ContentHash ComputeFromBytes(byte[] bytes)
        {
            using var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(bytes);

            var p1 = BitConverter.ToUInt64(hash, 0);
            var p2 = BitConverter.ToUInt64(hash, 8);

            return new ContentHash(new UInt128(p1, p2));
        }
    }
}
