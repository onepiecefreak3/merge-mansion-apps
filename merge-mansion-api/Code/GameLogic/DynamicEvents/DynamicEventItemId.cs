using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.DynamicEvents
{
    [MetaSerializable]
    public class DynamicEventItemId : StringId<DynamicEventItemId>
    {
        public DynamicEventItemId()
        {
        }
    }
}