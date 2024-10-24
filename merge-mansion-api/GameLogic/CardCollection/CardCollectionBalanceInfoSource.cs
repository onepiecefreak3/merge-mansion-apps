using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    public class CardCollectionBalanceInfoSource : IConfigItemSource<CardCollectionBalanceInfo, CardCollectionBalanceId>, IGameConfigSourceItem<CardCollectionBalanceId, CardCollectionBalanceInfo>, IHasGameConfigKey<CardCollectionBalanceId>
    {
        public CardCollectionBalanceId ConfigKey { get; set; }
        private List<CardCollectionCardActivationId> CardActivationIds { get; set; }
        private List<CardCollectionPackActivationId> PackActivationIds { get; set; }
        private List<CardCollectionHiddenRarityActivationId> HiddenRarityActivationIds { get; set; }
        private List<CardCollectionSetActivationId> SetActivationIds { get; set; }

        public CardCollectionBalanceInfoSource()
        {
        }
    }
}