namespace GameLogic.Player.Rewards
{
    public interface IRewardContext
    {
        public static IRewardContext None;
        CurrencySource FallbackCurrencySource { get; }
    }
}