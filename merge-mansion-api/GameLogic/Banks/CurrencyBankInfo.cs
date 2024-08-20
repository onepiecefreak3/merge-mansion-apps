using Metaplay.Core.Activables;
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.ComponentModel;
using System;
using Metaplay.Core;
using GameLogic.Config;
using System.Collections.Generic;
using Metaplay.Core.Math;

namespace GameLogic.Banks
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 8 })]
    [MetaActivableConfigData("CurrencyBankEvent", false, true)]
    public class CurrencyBankInfo : IMetaActivableConfigData<CurrencyBankId>, IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<CurrencyBankId>, IHasGameConfigKey<CurrencyBankId>, IMetaActivableInfo<CurrencyBankId>, IValidatable
    {
        [Description("Id of the bank")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencyBankId CurrencyBankId { get; set; }

        [Description("Localisation key of bank name")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [Description("Description about the bank")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Store product to purchase")]
        public MetaRef<InAppProductInfo> InAppProductInfo { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Stored currency type")]
        public Currencies CurrencyType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Minimum stored amount required for purchasing")]
        public int MinBuyAmount { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Maximun stored amount")]
        public int MaxBuyAmount { get; set; }

        [Description("Activable parameters")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public MetaActivableParams ActivableParams { get; set; }

        [Description("Item type used in info popup to show the chain items that should be merged to fill the bank")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public int InfoPopupItemId { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Item types which merge is increasing bank amount")]
        public List<int> MergeableItemTypes { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Multiplier used to fill the bank when merging")]
        public F64 MultiplierMerge { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Multiplier used to fill the bank when completing tasks")]
        public F64 MultiplierCompleteTask { get; set; }

        [Description("Multiplier used to fill the bank when spawning items using energy")]
        [MetaMember(14, (MetaMemberFlags)0)]
        public F64 MultiplierSpawnItemUsingEnergy { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Duration of the hidden preview state")]
        public MetaDuration? DurationStateHiddenPreview { get; set; }

        [Description("Duration of the not full state")]
        [MetaMember(16, (MetaMemberFlags)0)]
        public MetaDuration? DurationStateNotFull { get; set; }

        [Description("Duration of the full state")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public MetaDuration? DurationStateFull { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        [Description("Skip hidden preview on first activation")]
        public bool SkipHiddenPreviewOnFirstActivation { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("Max number of currency banks purchases to allow this one to be activated")]
        public int MaxNumOfStashesPerPlayer { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("Max number of currency banks activated to allow this one to be activated")]
        public int? MaxActivationsGlobal { get; set; }
        public CurrencyBankId ActivableId { get; }
        public CurrencyBankId ConfigKey => CurrencyBankId;
        public string DisplayShortInfo { get; }

        public CurrencyBankInfo()
        {
        }

        public CurrencyBankInfo(CurrencyBankId currencyBankId, string displayName, string description, MetaRef<InAppProductInfo> inAppProductInfo, Currencies currencyType, int minBuyAmount, int maxBuyAmount, F64 multiplierMerge, F64 multiplierCompleteTask, F64 multiplierSpawnItemUsingEnergy, int infoPopupItemId, List<int> mergeableItemTypes, MetaDuration? durationStateHiddenPreview, bool skipHiddenPreviewOnFirstActivation, MetaDuration? durationStateNotFull, MetaDuration? durationStateFull, MetaActivableParams activableParams, int maxNumOfStashesPerPlayer, int? maxActivationsGlobal)
        {
        }

        [Description("Recurrence - repeat time cycle after not full state start date")]
        [MetaMember(21, (MetaMemberFlags)0)]
        public MetaDuration? CustomRecurrence { get; set; }

        public CurrencyBankInfo(CurrencyBankId currencyBankId, string displayName, string description, MetaRef<InAppProductInfo> inAppProductInfo, Currencies currencyType, int minBuyAmount, int maxBuyAmount, F64 multiplierMerge, F64 multiplierCompleteTask, F64 multiplierSpawnItemUsingEnergy, int infoPopupItemId, List<int> mergeableItemTypes, MetaDuration? durationStateHiddenPreview, bool skipHiddenPreviewOnFirstActivation, MetaDuration? durationStateNotFull, MetaDuration? durationStateFull, MetaActivableParams activableParams, int maxNumOfStashesPerPlayer, int? maxActivationsGlobal, MetaDuration? customRecurrence)
        {
        }
    }
}