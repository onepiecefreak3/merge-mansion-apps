using Metaplay.Core.Player;
using System;

namespace Analytics
{
    public abstract class PlayerTriggerEvent : PlayerEventBase
    {
        public override string EventDescription { get; }

        protected PlayerTriggerEvent()
        {
        }
    }
}