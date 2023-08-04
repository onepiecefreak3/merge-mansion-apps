using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializable]
    public class ItemLeaderboardState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool ScoreClaimed { get; set; }

        public ItemLeaderboardState()
        {
        }
    }
}