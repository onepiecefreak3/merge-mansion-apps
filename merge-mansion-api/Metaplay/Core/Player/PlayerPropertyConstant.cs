using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Game.Logic;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    public abstract class PlayerPropertyConstant
    {
        public abstract class TypedConstant<TValue> : PlayerPropertyConstant
        {
            [MetaMember(1)]
            private TValue _value; // 0x0
        }

        [MetaSerializableDerived(1)]
        public class LongConstant: TypedConstant<long>
        {

        }

        [MetaSerializableDerived(2)]
        public class F64Constant : TypedConstant<F64>
        {

        }

        [MetaSerializableDerived(3)]
        public class MetaTimeConstant : TypedConstant<MetaTime>
        {

        }

        [MetaSerializableDerived(4)]
        public class MetaDurationConstant : TypedConstant<MetaDuration>
        {

        }

        [MetaSerializableDerived(5)]
        public class BoolConstant : TypedConstant<bool>
        {

        }

        [MetaSerializableDerived(6)]
        public class StringConstant : TypedConstant<string>
        {

        }

        [MetaSerializableDerived(7)]
        public class HotspotConstant : TypedConstant<HotspotId>
        {

        }

        [MetaSerializableDerived(9)]
        public class SurveyStringConstant : TypedConstant<SurveyString>
        {

        }
    }
}
