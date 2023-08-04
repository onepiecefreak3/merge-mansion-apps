using System;

namespace Metaplay.Core.Player
{
    public abstract class TypedPlayerPropertyId<TValue> : PlayerPropertyId
    {
        public override Type PropertyType { get; }

        protected TypedPlayerPropertyId()
        {
        }
    }
}