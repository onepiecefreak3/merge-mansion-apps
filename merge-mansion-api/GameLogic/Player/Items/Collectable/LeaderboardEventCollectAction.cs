using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(8)]
    [MetaSerializable]
    public class LeaderboardEventCollectAction : IProgressCollectAction
    {
        [MetaMember(1, 0)]
        private MetaRef<LeaderboardEventInfo> LeaderboardEventRef { get; set; }
        [MetaMember(2, 0)]
        public int Progress { get; set; }
    }
}
