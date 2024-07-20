using System.Collections.Generic;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Items.Consumption.Logic
{
    [MetaSerializableDerived(1)]
    public class LevelUpConsumptionLogic : IConsumptionLogic
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<string> ApplicableTags { get; set; }

        [IgnoreDataMember]
        private IConsumptionCheckResult MismatchedTags { get; set; }

        public LevelUpConsumptionLogic()
        {
        }

        public LevelUpConsumptionLogic(List<string> applicableTags)
        {
        }
    }
}