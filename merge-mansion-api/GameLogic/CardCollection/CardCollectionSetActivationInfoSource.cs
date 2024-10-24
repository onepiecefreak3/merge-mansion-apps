using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.Random.ControlledRandom;
using System.Collections.Generic;
using Metaplay.Core.Math;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionSetActivationInfoSource : IConfigItemSource<CardCollectionSetActivationInfo, CardCollectionSetActivationId>, IGameConfigSourceItem<CardCollectionSetActivationId, CardCollectionSetActivationInfo>, IHasGameConfigKey<CardCollectionSetActivationId>
    {
        public CardCollectionSetActivationId ConfigKey { get; set; }
        private CardStars CardStars { get; set; }
        private CardHiddenRarity HiddenRarity { get; set; }
        private RandomType RandomType { get; set; }
        private List<CardCollectionCardSetId> RandomSet { get; set; }
        private List<F32> RandomWeight { get; set; }
        private List<int> RandomMinBetweenTwoSame { get; set; }
        private List<int> RandomMaxBetweenTwoSame { get; set; }

        public CardCollectionSetActivationInfoSource()
        {
        }
    }
}