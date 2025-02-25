using Code.GameLogic.Config;
using GameLogic.CardCollection;
using Metaplay.Core.Config;

namespace Code.GameLogic.GameEvents.CardCollectionSupportingEvent
{
    public class CardCollectionSupportingEventReplacementPackSource : IConfigItemSource<CardCollectionSupportingEventReplacementPackInfo, CardCollectionPackId>, IGameConfigSourceItem<CardCollectionPackId, CardCollectionSupportingEventReplacementPackInfo>, IHasGameConfigKey<CardCollectionPackId>
    {
        public CardCollectionPackId ConfigKey { get; set; }
        public CardCollectionPackId PackReplacement { get; set; }

        public CardCollectionSupportingEventReplacementPackSource()
        {
        }
    }
}