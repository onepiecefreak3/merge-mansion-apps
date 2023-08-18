using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum ProgressionEventRewardClaimStatus
    {
        AlreadyClaimed = 0,
        CanBeClaimed = 1,
        RequiresProgress = 2,
        RequiresPremiumIAP = 3
    }
}