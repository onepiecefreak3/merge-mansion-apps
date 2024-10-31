using System;
using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public struct EntityId
    {
        public const int NumValueBits = 0x3a;
        public const ulong MaxValue = 0x400000000000000;
        public const ulong ValueMask = 0x3ffffffffffffff;
        public const string ValidIdCharacters = "023456789ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";
        public const int NumValidIdCharacters = 59;
        public const int IdLength = 10;
        public static EntityId None => Create(EntityKind.None, 0);

        [MetaMember(1, (MetaMemberFlags)0)]
        private ulong _rawValue;
        [MetaMember(2, (MetaMemberFlags)0)]
        private ushort _rawKind;
        public EntityKind Kind => new EntityKind((int)(_rawValue >> _rawKind));
        public ulong Value => _rawValue & ValueMask;
        public bool IsValid => EntityKindRegistry.IsValid(Kind) && EntityKind.None != Kind;

        private EntityId(ushort kind, ulong raw)
        {
            _rawKind = kind;
            _rawValue = raw;
        }

        public bool IsOfKind(EntityKind kind)
        {
            return Kind == kind;
        }

        public (string, string) GetKindValueStrings()
        {
            return (EntityKindRegistry.GetName(Kind), ValueToString(Value));
        }

        public bool Equals(EntityId other)
        {
            return _rawValue == other._rawValue;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityId idObj))
                return false;
            return _rawValue == idObj._rawValue;
        }

        public int CompareTo(EntityId other)
        {
            return _rawValue.CompareTo(other._rawValue);
        }

        public int CompareTo(object? obj)
        {
            return _rawValue.CompareTo(obj);
        }

        public override int GetHashCode()
        {
            return _rawValue.GetHashCode();
        }

        public override string ToString()
        {
            if (Kind != EntityKind.None)
                return $"{Kind}:{ValueToString(Value)}";
            if (Value != 0)
                return "None";
            return string.Concat("InvalidNone:", ValueToString(Value));
        }

        public static EntityId Create(EntityKind kind, ulong value)
        {
            if (value != 0 && kind == EntityKind.None)
                throw new ArgumentException("Value must be zero for EntityKind.None");
            if (kind.Value < EntityKind.MaxValue)
            {
                return new EntityId((ushort)kind.Value, value & ValueMask);
            //throw new ArgumentException($"Invalid EntityId value {kind.Value}:{value}");
            }

            throw new ArgumentException($"Invalid EntityKind value {kind.Value}");
        }

        public static EntityId CreateRandom(EntityKind kind)
        {
            var part1 = (ulong)Guid.NewGuid().GetHashCode();
            var part2 = (ulong)Guid.NewGuid().GetHashCode() & ValueMask;
            return new EntityId((ushort)kind.Value, (part1 << 0x20) + part2);
        }

        public static EntityId ParseFromString(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            if (str == "None")
                return None;
            var parts = str.Split(':');
            if (parts.Length != 2)
                throw new FormatException($"Invalid EntityId format '{str}'");
            if (parts[0] == "None")
                throw new FormatException($"EntityId None must not have value '{str}'");
            if (!EntityKindRegistry.TryFromName(parts[0], out var kind))
                throw new FormatException($"Invalid EntityKind in {str}");
            var parsedValue = ParseValue(parts[1]);
            //if (parsedValue >> _rawKind != 0)
            //    throw new FormatException($"Invalid value in {str}");
            return Create(kind, parsedValue);
        }

        public static EntityId ParseFromStringWithKind(EntityKind expectedKind, string str)
        {
            var parsed = ParseFromString(str);
            if (parsed.Kind != expectedKind)
                throw new FormatException($"Illegal EntityKind in {str}");
            return parsed;
        }

        public static string ValueToString(ulong val)
        {
            var res = new char[IdLength];
            for (var i = IdLength - 1; i >= 0; i--)
            {
                res[i] = ValidIdCharacters[(int)val + (int)(val / NumValidIdCharacters) * -NumValidIdCharacters];
                val /= NumValidIdCharacters;
            }

            return new string (res);
        }

        private static ulong ParseValue(string str)
        {
            if (str.Length != IdLength)
                throw new FormatException($"EntityId values are required to be exactly 10 characters, got {str.Length} in '{str}'");
            var res = 0ul;
            for (var i = 0; i < IdLength; i++)
            {
                var c = str[i];
                var ci = ValidIdCharacters.IndexOf(c);
                if (ci == -1)
                    throw new FormatException($"Invalid EntityId character '{str[i]}'");
                res = res * NumValidIdCharacters + (ulong)ci;
            }

            //if (res >> _rawKind != 0)
            //    throw new FormatException($"Invalid EntityId value '{str}'");
            return res;
        }

        public static bool operator ==(EntityId a, EntityId b) => a._rawValue == b._rawValue;
        public static bool operator !=(EntityId a, EntityId b) => a._rawValue != b._rawValue;
    }
}