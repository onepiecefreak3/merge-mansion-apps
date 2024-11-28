using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.Config.Costs;
using GameLogic.Player.Items;
using GameLogic.Player.Requirements;
using merge_mansion_dumper.Models.Area;
using Serilog;
using Serilog.Formatting.Display;

namespace merge_mansion_dumper.Dumper.Support
{
    static class RequirementSupport
    {
        public static IDictionary<RequirementType, IList<RequireModel>> GetRequirements(IList<PlayerRequirement> requirements, ILogger log = null)
        {
            var res = new Dictionary<RequirementType, IList<RequireModel>>();

            foreach (var require in requirements)
            {
                var requireInfos = GetRequirement(require, log);
                foreach (var requireInfo in requireInfos)
                {
                    if (!res.ContainsKey(requireInfo.Key))
                        res[requireInfo.Key] = new List<RequireModel>();

                    res[requireInfo.Key].Add(requireInfo.Value);
                }
            }

            return res.Count <= 0 ? null : res;
        }

        public static IList<KeyValuePair<RequirementType, RequireModel>> GetRequirement(PlayerRequirement playerReq, ILogger log = null)
        {
            switch (playerReq)
            {
                case PlayerLevelRequirement plr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.PlayerLevel, new RequireModel { Value = plr.Min.GetValueOrDefault(0).ToString() })
                    };

                case AreaCompletedRequirement acr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.AreaUnlocked, new RequireModel { Value = acr.AreaRef.Ref.AreaId.Value })
                    };

                case PlayerSeenItemRequirement psir:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.ItemSeen, new RequireModel { Value = psir.ItemRef.Ref.ConfigKey.ToString() })
                    };

                case HotspotCompletedRequirement hcr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.HotspotUnlocked, new RequireModel { Value = hcr.GetRequiredHotspot().ConfigKey.ToString() })
                    };

                case PlayerItemRequirement pir:
                    return pir.Items.Select(i => new KeyValuePair<RequirementType, RequireModel>(RequirementType.ItemAcquired, 
                        new RequireModel { Value = i.ToString(), Amount = pir.Requirement })).ToList();

                case CostRequirement cr:
                    switch (cr.RequiredCost)
                    {
                        case CurrencyCost cc:
                            return new List<KeyValuePair<RequirementType, RequireModel>>
                            {
                                new(RequirementType.Coins, new RequireModel { Amount = cc.CurrencyAmount })
                            };

                        default:
                            log?.Error("Unknown cost requirement type {0}.", cr.RequiredCost.GetType());
                            throw new InvalidOperationException($"Unknown cost requirement type {cr.RequiredCost.GetType()}.");
                    }

                case PlayerCurrentTimeRequirement pctr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.Time, new RequireModel { Value = $"{pctr.StartInclusive}{(pctr.EndExclusive.HasValue ? ";" + pctr.EndExclusive : "")}" })
                    };

                case SessionCountRequirement scr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.SessionCount, new RequireModel { Value = $"{scr.Min}{(scr.Max.HasValue ? "-" + scr.Max : "")}" })
                    };

                case PlayerInitialClientVersionRequirement picvr:
                    return new List<KeyValuePair<RequirementType, RequireModel>>
                    {
                        new(RequirementType.ClientVersion, new RequireModel { Value = $"{picvr.Min}-{picvr.Max}" })
                    };

                default:
                    log?.Error("Unknown requirement type {0}.", playerReq.GetType());
                    throw new InvalidOperationException($"Unknown requirement type {playerReq.GetType()}.");
            }
        }
    }
}
