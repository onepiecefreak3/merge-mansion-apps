using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionSettings : GameConfigKeyValue<CardCollectionSettings>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsEnabledCardPacksBonusOnShop { get; set; }

        public CardCollectionSettings()
        {
        }
    }
}