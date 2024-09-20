using Metaplay.Core.Model;
using GameLogic;

namespace Game.Logic
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum MergeMansionInGameMailContentType
    {
        Default = 0,
        ProgressionEventRewardMail = 1,
        ThirdPartySurveyCompletingRewardMail = 2,
        ProducerInventoryPermanentMail = 3
    }
}