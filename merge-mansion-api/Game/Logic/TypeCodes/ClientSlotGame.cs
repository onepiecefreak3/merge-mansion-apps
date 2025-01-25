using Metaplay.Core.Model;
using Metaplay.Core.Client;
using System;

namespace Game.Logic.TypeCodes
{
    [MetaSerializable]
    public class ClientSlotGame : ClientSlot
    {
        public static ClientSlot Leaderboard;
        public ClientSlotGame(int id, string name) : base(id, name)
        {
        }

        public static ClientSlot BoultonLeague;
        public static ClientSlot ShortLeaderboardEvent;
    }
}