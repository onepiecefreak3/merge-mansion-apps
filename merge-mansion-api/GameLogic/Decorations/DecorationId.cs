using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Decorations
{
    [MetaSerializable]
    public class DecorationId : StringId<DecorationId>
    {
        public static DecorationId None;
        public DecorationId()
        {
        }
    }
}