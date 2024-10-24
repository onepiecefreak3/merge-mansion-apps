using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionPackId : StringId<CardCollectionPackId>
    {
        public static CardCollectionPackId None;
        public CardCollectionPackId()
        {
        }
    }
}