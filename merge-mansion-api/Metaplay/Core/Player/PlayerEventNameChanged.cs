using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1000, "Name Changed", 1, "Player name has changed.", true, true, false)]
    public class PlayerEventNameChanged : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerEventNameChanged.ChangeSource Source { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string OldName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string NewName { get; set; }
        public override string EventDescription { get; }

        public PlayerEventNameChanged()
        {
        }

        public PlayerEventNameChanged(PlayerEventNameChanged.ChangeSource source, string oldName, string newName)
        {
        }

        [MetaSerializable]
        public enum ChangeSource
        {
            Player = 0,
            Admin = 1
        }
    }
}