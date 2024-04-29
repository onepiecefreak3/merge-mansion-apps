using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineSpecialSaleSource : IConfigItemSource<MysteryMachineSpecialSaleInfo, MysteryMachineSpecialSaleId>, IGameConfigSourceItem<MysteryMachineSpecialSaleId, MysteryMachineSpecialSaleInfo>, IHasGameConfigKey<MysteryMachineSpecialSaleId>
    {
        public MysteryMachineSpecialSaleId ConfigKey { get; set; }
        private string Item { get; set; }
        private Currencies CostCurrency { get; set; }
        private int InitialCostAmount { get; set; }
        private int FreeItemWeight { get; set; }
        private MysteryMachineSaleFeatureId MachineFeature { get; set; }
        private int MaxPurchaseCount { get; set; }

        public MysteryMachineSpecialSaleSource()
        {
        }
    }
}