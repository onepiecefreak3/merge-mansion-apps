using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System.Collections.Generic;

namespace Metaplay.Core.LiveOpsEvent
{
    [ModelAction(10306)]
    public class PlayerClearLiveOpsEventUpdates : PlayerActionCore<IPlayerModelBase>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MetaGuid> UpdatesToClear { get; set; }

        private PlayerClearLiveOpsEventUpdates()
        {
        }

        public PlayerClearLiveOpsEventUpdates(List<MetaGuid> updatesToClear)
        {
        }
    }
}