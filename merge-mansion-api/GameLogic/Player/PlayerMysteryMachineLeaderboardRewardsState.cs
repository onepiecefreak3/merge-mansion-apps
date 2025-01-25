using Metaplay.Core.Model;
using Metaplay.Core;
using System;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 2 })]
    public class PlayerMysteryMachineLeaderboardRewardsState
    {
        private static MetaDuration requestRewardsCooldown;
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<EventInstanceId, MysteryMachineLeaderboardPositionData> PositionsByEventInstanceId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<MysteryMachineLeaderboardEventInstanceData> ClaimRewardsEventInstances { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaTime? LastRequestRewardsTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private List<RequestMysteryMachineLeaderboardRewardsEventInstanceData> RequestRewardsEventInstances { get; set; }

        public PlayerMysteryMachineLeaderboardRewardsState()
        {
        }
    }
}