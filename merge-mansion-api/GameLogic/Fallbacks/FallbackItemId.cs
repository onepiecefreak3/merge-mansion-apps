using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Fallbacks
{
    [MetaSerializable]
    public class FallbackItemId : StringId<FallbackItemId>
    {
        public static FallbackItemId None;
        public FallbackItemId()
        {
        }
    }
}