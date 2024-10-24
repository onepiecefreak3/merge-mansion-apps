using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionPackActivationId : StringId<CardCollectionPackActivationId>
    {
        public static CardCollectionPackActivationId None;
        public CardCollectionPackActivationId()
        {
        }
    }
}