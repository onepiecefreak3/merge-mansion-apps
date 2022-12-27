using System;
using System.Collections.Generic;
using merge_mansion_cli.Models.Area;
using Metaplay;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.Player.Requirements;
using Serilog;
using Serilog.Formatting.Display;

namespace merge_mansion_cli.Dumper.Support
{
    static class RequirementSupport
    {
        public static IDictionary<RequirementType, IList<RequireModel>> GetRequirements(IList<PlayerRequirement> requirements, ILogger log = null)
        {
            var res = new Dictionary<RequirementType, IList<RequireModel>>();

            foreach (var require in requirements)
            {
                var requireInfo = GetRequirement(require, log);

                if (!res.ContainsKey(requireInfo.Key))
                    res[requireInfo.Key] = new List<RequireModel>();
                res[requireInfo.Key].Add(requireInfo.Value);
            }

            return res.Count <= 0 ? null : res;
        }

        public static KeyValuePair<RequirementType, RequireModel> GetRequirement(PlayerRequirement playerReq, ILogger log = null)
        {
            switch (playerReq)
            {
                case PlayerLevelRequirement plr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.PlayerLevel,
                        new RequireModel { Value = plr.Min.GetValueOrDefault(0).ToString() });

                case AreaCompletedRequirement acr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.AreaUnlocked,
                        new RequireModel { Value = acr.AreaRef.Ref.AreaId.Value });

                case PlayerSeenItemRequirement psir:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.ItemSeen,
                        new RequireModel { Value = psir.ItemRef.Ref.ConfigKey.ToString() });

                case HotspotCompletedRequirement hcr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.HotspotUnlocked,
                        new RequireModel { Value = hcr.hotspot.Ref.ConfigKey.ToString() });

                case PlayerItemRequirement pir:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.ItemAcquired,
                        new RequireModel { Value = pir.Item.ConfigKey.ToString(), Amount = pir.Requirement });

                case CostRequirement cr:
                    switch (cr.RequiredCost)
                    {
                        case CurrencyCost cc:
                            return new KeyValuePair<RequirementType, RequireModel>(RequirementType.Coins,
                                new RequireModel { Amount = cc.CurrencyAmount });

                        default:
                            log?.Error("Unknown cost requirement type {0}.", cr.RequiredCost.GetType());
                            throw new InvalidOperationException($"Unknown cost requirement type {cr.RequiredCost.GetType()}.");
                    }

                case PlayerCurrentTimeRequirement pctr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.Time,
                        new RequireModel { Value = $"{pctr.StartInclusive}{(pctr.EndExclusive.HasValue ? ";" + pctr.EndExclusive : "")}" });

                case SessionCountRequirement scr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.SessionCount,
                        new RequireModel { Value = $"{scr.Min}{(scr.Max.HasValue ? "-" + scr.Max : "")}" });

                case PlayerInitialClientVersionRequirement picvr:
                    return new KeyValuePair<RequirementType, RequireModel>(RequirementType.ClientVersion,
                        new RequireModel { Value = $"{picvr.Min}-{picvr.Max}" });

                default:
                    log?.Error("Unknown requirement type {0}.", playerReq.GetType());
                    throw new InvalidOperationException($"Unknown requirement type {playerReq.GetType()}.");
            }
        }
    }
}
