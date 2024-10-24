using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class TemporaryCardCollectionEventId : StringId<TemporaryCardCollectionEventId>
    {
        public static TemporaryCardCollectionEventId None;
        public TemporaryCardCollectionEventId()
        {
        }
    }
}