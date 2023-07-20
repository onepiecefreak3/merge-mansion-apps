using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Consumption.Logic
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class LevelUpConsumptionLogic : IConsumptionLogic
    {
        [MetaMember(1, 0)]
        public List<string> ApplicableTags { get; set; }
    }
}
