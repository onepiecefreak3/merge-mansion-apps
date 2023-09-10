using System;

namespace Metaplay.Core.Player
{
    public abstract class TypedPlayerPropertyId<TValue> : PlayerPropertyId
    {
        public override Type PropertyType => typeof(TValue);

        protected TypedPlayerPropertyId()
        {
        }
    }
}