using System;

namespace Metaplay.Core.Player
{
    public abstract class PlayerPropertyId
    {
        public abstract Type PropertyType { get; }
        public abstract string DisplayName { get; }

        protected PlayerPropertyId()
        {
        }
    }
}