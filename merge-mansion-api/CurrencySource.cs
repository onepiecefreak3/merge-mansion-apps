using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay
{
    public enum CurrencySource
    {
        Unknown = 0,
        TestCase = 1,
        DebugMenu = 2,
        Regeneration = 3,
        ForcedGameReset = 4,
        SupportGivenReward = 5,
        IAPPurchase = 6,
        ShopPurchase = 7,
        SimulationAction = 8,
        ItemCollected = 9,
        ItemSold = 10,
        HotspotCompleted = 11,
        Questionnaire12Traits = 12,
        SocialLoginReward = 13,
        SocialMediaReward = 14,
        IAPShopOfferPurchase = 15,
        BoardEventTaskClaim = 16,
        GameEventLevelUp = 17,
        GameEventEndedCurrencyConversion = 18,
        ShopEventOfferPurchase = 19,
        SurveyReward = 20,
        Migration = 21,
        DailyTaskReward = 22,
        DiscoveryReward = 23,
        GarageCleanup = 24,
        AreaCompleted = 25,
        AutoCollected = 26,
    }
}
