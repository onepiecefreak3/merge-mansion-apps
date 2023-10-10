using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic
{
    [MetaSerializableDerived(4)]
    public class CollectibleBoardEventIdArg : SerializableArg<CollectibleBoardEventId>
    {
        private CollectibleBoardEventIdArg()
        {
        }

        public CollectibleBoardEventIdArg(CollectibleBoardEventId value)
        {
        }
    }
}