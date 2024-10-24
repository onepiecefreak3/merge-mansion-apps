using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player
{
    [MetaSerializable]
    public struct RequestMysteryMachineLeaderboardRewardsEventInstanceData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardEventInstanceData EventInstance { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime EarliestRequestTime { get; set; }
    }
}