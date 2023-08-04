using System;

namespace GameLogic.Player.Rewards
{
    public interface ICurrencyReward
    {
        Currencies Currency { get; }

        int Amount { get; }
    }
}