using Metaplay.Core.Model;
using Game.Logic.Message;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class AcknowledgedMysteryMachineLeaderboardPositionData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardSelfEntry SelfEntry { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardPercentileData NextPercentile { get; set; }

        public AcknowledgedMysteryMachineLeaderboardPositionData()
        {
        }

        public AcknowledgedMysteryMachineLeaderboardPositionData(MysteryMachineLeaderboardSelfEntry selfEntry, MysteryMachineLeaderboardPercentileData nextPercentile)
        {
        }
    }
}