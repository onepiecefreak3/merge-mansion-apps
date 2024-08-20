using Metaplay.Core.Model;

namespace GameLogic.Player.Events
{
    [MetaSerializable]
    public enum SoloMilestoneEventState
    {
        Inactive = 0,
        Active = 1,
        AllRewardsClaimed = 2
    }
}