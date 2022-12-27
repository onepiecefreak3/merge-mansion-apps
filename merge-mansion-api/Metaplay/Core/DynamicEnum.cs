using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Metaplay.Core.Client;

namespace Metaplay.Metaplay.Core
{
    public class DynamicEnum<TEnum> : IDynamicEnum, IEquatable<DynamicEnum<TEnum>>/*, IComparable<DynamicEnum<TEnum>>, IComparable*/
        where TEnum : DynamicEnum<TEnum>
    {
        private static readonly Lazy<List<TEnum>> _allValues = new Lazy<List<TEnum>>(FindAllValues); // 0x0
        private static readonly Lazy<Dictionary<string, TEnum>> _nameToValue = new Lazy<Dictionary<string, TEnum>>(() => FindAllValues().ToDictionary(x => x.Name, y => y)); // 0x8
        private static readonly Lazy<Dictionary<int, TEnum>> _idToValue = new Lazy<Dictionary<int, TEnum>>(() => FindAllValues().ToDictionary(x => x.Id, y => y)); // 0x10

        public static List<TEnum> AllValues => _allValues.Value;

        public int Id { get; set; } // 0x10
        public string Name { get; set; } // 0x18
        public bool IsValid { get; set; } // 0x20

        protected DynamicEnum(int id, string name, bool isValid)
        {
            Id = id;
            Name = name;
            IsValid = isValid;
        }

        public static TEnum FromName(string name)
        {
            return _nameToValue.Value[name];
        }

        public static bool TryFromName(string name, out TEnum value)
        {
            value = default;

            if (!_nameToValue.Value.ContainsKey(name))
                return false;

            value = _nameToValue.Value[name];
            return true;
        }

        public static TEnum FromId(int id)
        {
            return _idToValue.Value[id];
        }

        public static bool TryFromId(int id, out TEnum value)
        {
            value = default;

            if (!_idToValue.Value.ContainsKey(id))
                return false;

            value = _idToValue.Value[id];
            return true;
        }

        public bool Equals(DynamicEnum<TEnum> obj)
        {
            return this == obj;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DynamicEnum<TEnum> enumObj))
                return false;

            return this == enumObj;
        }

        public static bool operator ==(DynamicEnum<TEnum> a, DynamicEnum<TEnum> b) => a.Id == b.Id && a.Name == b.Name && a.IsValid == b.IsValid;
        public static bool operator !=(DynamicEnum<TEnum> a, DynamicEnum<TEnum> b) => a.Id != b.Id || a.Name != b.Name || a.IsValid != b.IsValid;

        private static List<TEnum> FindAllValues()
        {
            // HINT: I'm way too lazy to figure out this logic. Either use enums or don't. DynamicEnums are a crime in C# and should be an unforgivable sin
            // I just manually plug every DynamicEnum member in the codebase here
            if (typeof(TEnum) == typeof(ClientSlot))
                return new List<ClientSlot>
                {
                    ClientSlotCore.Player,
                    ClientSlotCore.Guild,
                }.Cast<TEnum>().ToList();

            return null;
        }
    }
}
