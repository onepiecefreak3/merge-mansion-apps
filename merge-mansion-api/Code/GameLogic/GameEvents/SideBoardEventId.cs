using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class SideBoardEventId : StringId<SideBoardEventId>
    {
        public static SideBoardEventId None;
        public SideBoardEventId()
        {
        }
    }
}