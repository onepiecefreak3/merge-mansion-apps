using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Bubble
{
    public class BubblesSetup : IGameConfigData<BubblesSetupId>
    {
        [MetaMember(1, 0)]
        public BubblesSetupId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public IBubbleLogic Logic { get; set; }
    }
}
