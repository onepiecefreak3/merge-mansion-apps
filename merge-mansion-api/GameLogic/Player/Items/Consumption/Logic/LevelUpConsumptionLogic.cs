using System.Collections.Generic;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Consumption.Logic
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class LevelUpConsumptionLogic : IConsumptionLogic
    {
        [MetaMember(1, 0)]
        public List<string> ApplicableTags { get; set; }
    }
}
