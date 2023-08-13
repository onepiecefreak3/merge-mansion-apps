using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Session
{
    [MetaSerializable]
    public struct SessionToken
    {
        [MetaMember(1, 0)]
        public ulong Value { get; set; } // 0x0

        public SessionToken(ulong value)
        {
            Value = value;
        }

        public static SessionToken CreateRandom()
        {
            var part1 = Guid.NewGuid().GetHashCode();
            var part2 = Guid.NewGuid().GetHashCode();
            return new SessionToken((ulong)part1 << 0x20 + part2);
        }

        public static bool operator ==(SessionToken a, SessionToken b) => a.Value == b.Value;
        public static bool operator !=(SessionToken a, SessionToken b) => a.Value != b.Value;
        public override bool Equals(object obj)
        {
            if (!(obj is SessionToken stObj))
                return false;
            return Value == stObj.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return $"SessionToken({Value:X16})";
        }
    }
}