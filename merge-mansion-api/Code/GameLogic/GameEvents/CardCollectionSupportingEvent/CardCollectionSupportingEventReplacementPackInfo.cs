using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.CardCollection;
using Code.GameLogic.Config;

namespace Code.GameLogic.GameEvents.CardCollectionSupportingEvent
{
    [MetaSerializable]
    public class CardCollectionSupportingEventReplacementPackInfo : IGameConfigData<CardCollectionPackId>, IGameConfigData, IHasGameConfigKey<CardCollectionPackId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionPackId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public CardCollectionPackId PackReplacement { get; set; }

        public CardCollectionSupportingEventReplacementPackInfo()
        {
        }

        public CardCollectionSupportingEventReplacementPackInfo(CardCollectionPackId configKey, CardCollectionPackId packReplacement)
        {
        }
    }
}