using Metaplay.Core.Model;
using Metaplay.Core.Player;

namespace GameLogic.Config
{
    public abstract class PlayerPropertyMatcher : PlayerPropertyId
    {
    }

    [MetaSerializable]

    public abstract class PlayerPropertyMatcher<TValue> : PlayerPropertyMatcher
    {
        [MetaMember(100, 0)]
        protected TValue _value { get; set; }
    }
}
