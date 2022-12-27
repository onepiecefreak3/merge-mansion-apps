using System;

namespace Metaplay.Metaplay.Core
{
    public struct EntityKind : IEquatable<EntityKind>
    {
        public const int MaxValue = 64;

        public static readonly EntityKind None = new EntityKind(0); // 0x0

        public readonly int Value; // 0x0

        public string Name => EntityKindRegistry.GetName(this);

        public EntityKind(int value)
        {
            if (value >= MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            Value = value;
        }

        public bool Equals(EntityKind other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityKind idObj))
                return false;

            return Value == idObj.Value;
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public override string ToString()
        {
            return EntityKindRegistry.GetName(this);
        }

        public static EntityKind FromValue(int value)
        {
            return new EntityKind(value);
        }

        public static EntityKind FromName(string name)
        {
            return EntityKindRegistry.FromName(name);
        }

        public static bool operator ==(EntityKind a, EntityKind b) => a.Value == b.Value;
        public static bool operator !=(EntityKind a, EntityKind b) => a.Value != b.Value;
    }
}
