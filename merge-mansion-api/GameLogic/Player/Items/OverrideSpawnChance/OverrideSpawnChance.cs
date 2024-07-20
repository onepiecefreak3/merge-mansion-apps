using Metaplay.Core.Model;
using GameLogic.Player.Requirements;
using Merge;
using System.Collections.Generic;
using GameLogic.Config;

namespace GameLogic.Player.Items.OverrideSpawnChance
{
    [MetaBlockedMembers(new int[] { 4 })]
    [MetaSerializable]
    public class OverrideSpawnChance
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerRequirement TriggerRequirement { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerRequirement EndRequirement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MergeBoardId TargetBoardId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<QuantityPercentagePair> ChancesToSpawn { get; set; }

        public OverrideSpawnChance()
        {
        }

        public OverrideSpawnChance(PlayerRequirement triggerRequirement, PlayerRequirement endRequirement, MergeBoardId targetBoardId, List<QuantityPercentagePair> chancesToSpawn)
        {
        }
    }
}