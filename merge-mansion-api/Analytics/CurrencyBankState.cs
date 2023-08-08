using Metaplay.Core.Model;

namespace Analytics
{
    [MetaSerializable]
    public enum CurrencyBankState
    {
        Started = 0,
        Ended = 1,
        Full = 2,
        Purchased = 3
    }
}