using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    public abstract class MetaReward
    {
        public virtual string Description { get; }

        protected MetaReward()
        {
        }
    }
}