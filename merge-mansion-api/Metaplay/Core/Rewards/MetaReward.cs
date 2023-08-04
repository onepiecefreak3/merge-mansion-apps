using System;

namespace Metaplay.Core.Rewards
{
    public abstract class MetaReward
    {
        public virtual string Description { get; }

        protected MetaReward()
        {
        }
    }
}