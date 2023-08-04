using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    public abstract class PlayerPropertyMatcher : PlayerPropertyId
    {
        public sealed override Type PropertyType { get; }

        protected PlayerPropertyMatcher()
        {
        }
    }

    [MetaSerializable]
    public abstract class PlayerPropertyMatcher<TValue> : PlayerPropertyMatcher
    {
        [MetaMember(100, 0)]
        protected TValue _value { get; set; }

        protected PlayerPropertyMatcher()
        {
        }
    }
}