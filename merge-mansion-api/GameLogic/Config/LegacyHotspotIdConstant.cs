using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(7)]
    public class LegacyHotspotIdConstant : PlayerPropertyConstant
    {
        public override object ConstantValue { get; }

        public LegacyHotspotIdConstant()
        {
        }
    }
}