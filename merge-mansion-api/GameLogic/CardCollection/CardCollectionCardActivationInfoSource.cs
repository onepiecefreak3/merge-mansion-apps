using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionCardActivationInfoSource : IConfigItemSource<CardCollectionCardActivationInfo, CardCollectionCardActivationId>, IGameConfigSourceItem<CardCollectionCardActivationId, CardCollectionCardActivationInfo>, IHasGameConfigKey<CardCollectionCardActivationId>
    {
        public CardCollectionCardActivationId ConfigKey { get; set; }
        private CardCollectionCardSetId CardSetId { get; set; }
        private List<CardStars> CardStars { get; set; }
        private List<int> CommonCards { get; set; }
        private List<int> CommonMin { get; set; }
        private List<int> CommonMax { get; set; }
        private List<int> RareCards { get; set; }
        private List<int> RareMin { get; set; }
        private List<int> RareMax { get; set; }
        private List<int> EpicCards { get; set; }
        private List<int> EpicMin { get; set; }
        private List<int> EpicMax { get; set; }

        public CardCollectionCardActivationInfoSource()
        {
        }
    }
}