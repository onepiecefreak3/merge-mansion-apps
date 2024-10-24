using System;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Rewards
{
    [MetaSerializable]
    [MetaFormUseAsContext]
    public abstract class MetaReward
    {
        public virtual string Description { get; }

        protected MetaReward()
        {
        }
    }
}