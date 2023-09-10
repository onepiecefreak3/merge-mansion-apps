using Game.Logic;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;
using GameLogic;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public abstract class PlayerPropertyConstant
    {
        [MetaSerializable]
        public abstract class TypedConstant<TValue> : PlayerPropertyConstant
        {
            [MetaMember(1)]
            private TValue _value; // 0x0

            public override object ConstantValue => _value;

            protected TypedConstant()
            {
            }

            protected TypedConstant(TValue value)
            {
            }
        }

        [MetaSerializableDerived(1)]
        public class LongConstant : TypedConstant<long>
        {
            private LongConstant()
            {
            }

            public LongConstant(long value)
            {
            }
        }

        [MetaSerializableDerived(2)]
        public class F64Constant : TypedConstant<F64>
        {
            private F64Constant()
            {
            }

            public F64Constant(F64 value)
            {
            }
        }

        [MetaSerializableDerived(3)]
        public class MetaTimeConstant : TypedConstant<MetaTime>
        {
            private MetaTimeConstant()
            {
            }

            public MetaTimeConstant(MetaTime value)
            {
            }
        }

        [MetaSerializableDerived(4)]
        public class MetaDurationConstant : TypedConstant<MetaDuration>
        {
            private MetaDurationConstant()
            {
            }

            public MetaDurationConstant(MetaDuration value)
            {
            }
        }

        [MetaSerializableDerived(5)]
        public class BoolConstant : TypedConstant<bool>
        {
            private BoolConstant()
            {
            }

            public BoolConstant(bool value)
            {
            }
        }

        [MetaSerializableDerived(6)]
        public class StringConstant : TypedConstant<string>
        {
            private StringConstant()
            {
            }

            public StringConstant(string value)
            {
            }
        }

        [MetaSerializableDerived(7)]
        public class HotspotConstant : TypedConstant<HotspotId>
        {
        }

        [MetaSerializableDerived(9)]
        public class SurveyStringConstant : TypedConstant<SurveyString>
        {
        }

        private static string[] s_dateTimeFormats;
        public abstract object ConstantValue { get; }

        protected PlayerPropertyConstant()
        {
        }
    }
}