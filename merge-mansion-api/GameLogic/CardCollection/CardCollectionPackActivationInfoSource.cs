using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using GameLogic.Random.ControlledRandom;
using Metaplay.Core.Math;

namespace GameLogic.CardCollection
{
    public class CardCollectionPackActivationInfoSource : IConfigItemSource<CardCollectionPackActivationInfo, CardCollectionPackActivationId>, IGameConfigSourceItem<CardCollectionPackActivationId, CardCollectionPackActivationInfo>, IHasGameConfigKey<CardCollectionPackActivationId>
    {
        public CardCollectionPackActivationId ConfigKey { get; set; }
        private CardCollectionPackId PackId { get; set; }
        private List<CardCollectionCardId> InitialSequence { get; set; }
        private List<CardStars> FixedCardStars { get; set; }
        private List<int> FixedAmount { get; set; }
        private CardsToRollFirst CardsToRollFirst { get; set; }
        private int RandomRolls { get; set; }
        private RandomType RandomType { get; set; }
        private List<CardStars> RandomCardStars { get; set; }
        private List<F32> RandomWeight { get; set; }
        private List<int> RandomMinBetweenTwoSame { get; set; }
        private List<int> RandomMaxBetweenTwoSame { get; set; }

        public CardCollectionPackActivationInfoSource()
        {
        }
    }
}