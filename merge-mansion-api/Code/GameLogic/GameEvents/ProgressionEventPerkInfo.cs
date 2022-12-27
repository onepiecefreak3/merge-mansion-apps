using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    public class ProgressionEventPerkInfo : IGameConfigData<ProgressionEventPerkId>
    {
        [MetaMember(1, 0)]
        public ProgressionEventPerkId Id { get; set; }
        [MetaMember(2, 0)]
        public ProgressionEventPerk Perk { get; set; }

        public ProgressionEventPerkId ConfigKey => Id;
    }
}
