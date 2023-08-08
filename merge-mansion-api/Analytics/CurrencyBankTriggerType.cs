using Metaplay.Core.Model;

namespace Analytics
{
    [MetaSerializable]
    public enum CurrencyBankTriggerType
    {
        None = 0,
        Merge = 1,
        Task = 2,
        SpawnItemUsingEnergy = 3
    }
}