using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaAllowNoSerializedMembers]
    [MetaSerializable]
    public abstract class PlayerPropertyId
    {
        public abstract Type PropertyType { get; }
        public abstract string DisplayName { get; }

        protected PlayerPropertyId()
        {
        }
    }
}