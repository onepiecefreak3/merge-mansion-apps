using Metaplay.Core.Model;
using GameLogic;

namespace Game.Logic
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum MergeMansionInGameMailContentType
    {
        Default = 0,
        ProgressionEventRewardMail = 1,
        ThirdPartySurveyCompletingRewardMail = 2
    }
}