using Metaplay.Core.Model;

namespace GameLogic.Inventory
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum RentableInventoryState
    {
        Inactive = 0,
        Expired = 1,
        ExpiredPrompted = 2,
        Active = 3
    }
}