using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic;

namespace Game.Logic
{
    [MetaSerializable]
    public class GameSettings
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private bool soundEffects { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private bool music { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private bool masterNotificationsOn { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<NotificationCategories> blacklistedNotifications { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private float musicVolume { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private float soundVolume { get; set; }

        public GameSettings()
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        private bool mergeHints { get; set; }
        private bool sinkTooltip { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private bool hapticsEnabled { get; set; }
    }
}