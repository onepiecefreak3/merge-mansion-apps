using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using GameLogic.Player.Items;
using GameLogic;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineSpecialSaleInfo : IGameConfigData<MysteryMachineSpecialSaleId>, IGameConfigData, IHasGameConfigKey<MysteryMachineSpecialSaleId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineSpecialSaleId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public Currencies CostCurrency { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int InitialCostAmount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int FreeItemWeight { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MysteryMachineSaleFeatureId MachineFeature { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int MaxPurchaseCount { get; set; }

        public MysteryMachineSpecialSaleInfo()
        {
        }

        public MysteryMachineSpecialSaleInfo(MysteryMachineSpecialSaleId configKey, MetaRef<ItemDefinition> itemRef, Currencies costCurrency, int initialCostAmount, int freeItemWeight, MysteryMachineSaleFeatureId machineFeature, int maxPurchaseCount)
        {
        }
    }
}