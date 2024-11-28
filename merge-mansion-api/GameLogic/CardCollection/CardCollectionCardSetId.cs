using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionCardSetId : StringId<CardCollectionCardSetId>
    {
        public CardCollectionCardSetId()
        {
        }

        public static CardCollectionCardSetId None;
    }
}