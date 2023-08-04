using Metaplay.Core.Model;

namespace GameLogic.Banks
{
    [MetaSerializable]
    public enum CurrencyBankState
    {
        IsDisabled = 0,
        IsUnderThreshold = 1,
        IsPurchaseableNotFull = 2,
        IsPurchaseableFull = 3
    }
}