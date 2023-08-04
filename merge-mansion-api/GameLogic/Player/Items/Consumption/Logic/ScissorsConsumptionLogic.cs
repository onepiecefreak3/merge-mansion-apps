using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Items.Consumption.Logic
{
    [MetaSerializableDerived(2)]
    public class ScissorsConsumptionLogic : IConsumptionLogic
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<string> AllowedTags { get; set; }

        private ScissorsConsumptionLogic()
        {
        }

        public ScissorsConsumptionLogic(IEnumerable<string> allowedTags)
        {
        }
    }
}