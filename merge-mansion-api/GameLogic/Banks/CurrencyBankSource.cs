using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core.Schedule;
using Metaplay.Core.Activables;
using Metaplay.Core.Player;

namespace GameLogic.Banks
{
    public class CurrencyBankSource : IConfigItemSource<CurrencyBankInfo, CurrencyBankId>, IGameConfigSourceItem<CurrencyBankId, CurrencyBankInfo>, IHasGameConfigKey<CurrencyBankId>
    {
        public CurrencyBankId ConfigKey { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public MetaRef<InAppProductInfo> InAppProductInfo { get; set; }
        public Currencies CurrencyType { get; set; }
        public int MinBuyAmount { get; set; }
        public int MaxBuyAmount { get; set; }
        public F64 MultiplierMerge { get; set; }
        public F64 MultiplierCompleteTask { get; set; }
        public F64 MultiplierSpawnItemUsingEnergy { get; set; }
        public string InfoPopupItemId { get; set; }
        public string MergeableItemTypes { get; set; }
        public int MaxNumOfStashesPerPlayer { get; set; }
        public int? MaxActivationsGlobal { get; set; }
        private bool IsEnabled { get; set; }
        public MetaDuration? DurationStateHiddenPreview { get; set; }
        public bool SkipHiddenPreviewOnFirstActivation { get; set; }
        public MetaDuration? DurationStateFull { get; set; }
        public List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        public MetaDuration? DurationStateNotFull { get; set; }
        private int? MaxActivations { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        public MetaActivableLifetimeSpec Lifetime { get; set; }
        public MetaDuration? CustomRecurrence { get; set; }

        public CurrencyBankSource()
        {
        }
    }
}