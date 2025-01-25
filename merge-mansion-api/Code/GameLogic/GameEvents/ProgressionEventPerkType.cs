using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum ProgressionEventPerkType
    {
        None = 0,
        FreeShopItem = 1,
        ExtraInventorySlots = 2,
        FreeDailyShopItem = 3,
        FreeDailyCurrency = 4,
        EventXp = 5
    }
}