using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;

namespace GameLogic
{
    [MetaSerializableDerived(6)]
    public class SideBoardEventIdArg : SerializableArg<SideBoardEventId>
    {
        private SideBoardEventIdArg()
        {
        }

        public SideBoardEventIdArg(SideBoardEventId value)
        {
        }
    }
}