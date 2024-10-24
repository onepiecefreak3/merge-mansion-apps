using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.Random.ControlledRandom;
using System.Collections.Generic;
using Metaplay.Core.Math;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionHiddenRarityActivationInfoSource : IConfigItemSource<CardCollectionHiddenRarityActivationInfo, CardCollectionHiddenRarityActivationId>, IGameConfigSourceItem<CardCollectionHiddenRarityActivationId, CardCollectionHiddenRarityActivationInfo>, IHasGameConfigKey<CardCollectionHiddenRarityActivationId>
    {
        public CardCollectionHiddenRarityActivationId ConfigKey { get; set; }
        private CardStars CardStars { get; set; }
        private RandomType RandomType { get; set; }
        private List<CardHiddenRarity> RandomHiddenRarity { get; set; }
        private List<F32> RandomWeight { get; set; }
        private List<int> RandomMinBetweenTwoSame { get; set; }
        private List<int> RandomMaxBetweenTwoSame { get; set; }

        public CardCollectionHiddenRarityActivationInfoSource()
        {
        }
    }
}