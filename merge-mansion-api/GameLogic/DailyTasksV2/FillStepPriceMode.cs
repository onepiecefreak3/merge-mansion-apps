using Metaplay.Core.Model;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public enum FillStepPriceMode
    {
        ChosenItemValueReward = 0,
        ChosenItemValueRequirement = 1,
        ExpectedItemValueReward = 2
    }
}