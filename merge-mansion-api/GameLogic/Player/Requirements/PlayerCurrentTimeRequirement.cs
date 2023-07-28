using System;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(11)]
    [MetaSerializable]
    public class PlayerCurrentTimeRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public Nullable<MetaTime> StartInclusive { get; set; }
        [MetaMember(2, 0)]
        public Nullable<MetaTime> EndExclusive { get; set; }
        [MetaMember(3, 0)]
        public string LocalizationKey { get; set; }
    }
}
