using System;
using System.Collections.Generic;
using merge_mansion_dumper.Models.Area;
using Metaplay.GameLogic.Player.Rewards;

namespace merge_mansion_dumper.Dumper.Support
{
    static class RewardSupport
    {
        public static IList<RewardModel> GetRewards(IList<PlayerReward> rewards)
        {
            var res = new List<RewardModel>();

            foreach (var reward in rewards)
                res.Add(GetReward(reward));

            return res.Count <= 0 ? null : res;
        }

        private static RewardModel GetReward(PlayerReward reward)
        {
            switch (reward)
            {
                case RewardItem item:
                    return new RewardModel { Type = RewardType.Item, Value = item.ItemRef.Ref.ConfigKey.ToString(), Amount = item.Amount };

                case RewardExperience exp:
                    return new RewardModel { Type = RewardType.Experience, Amount = exp.Amount };

                case RewardCoins rec:
                    return new RewardModel { Type = RewardType.Coins, Amount = rec.Amount };

                case RewardDiamonds red:
                    return new RewardModel { Type = RewardType.Diamonds, Amount = red.Amount };

                case RewardDecoration redc:
                    return new RewardModel { Type = RewardType.Decoration, Value = redc.Decoration.DecorationId.Value, Amount = 1};

                case RewardEventCurrency evc:
                    return new RewardModel { Type = RewardType.EventCurrency, Value = evc.EventCurrencyId.Value, Amount = evc.Amount };

                case RewardEventPoints evp:
                    return new RewardModel { Type = RewardType.EventPoints, Value = evp.EventId.Value, Amount = evp.Amount };

                default:
                    throw new InvalidOperationException($"Unknown reward {reward.GetType()}.");
            }
        }
    }
}
