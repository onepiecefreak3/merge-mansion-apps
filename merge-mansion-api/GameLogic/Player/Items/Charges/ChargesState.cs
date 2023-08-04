using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Charges
{
    [MetaSerializable]
    public class ChargesState
    {
        private static ChargesState empty;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Charges { get; set; }

        public ChargesState()
        {
        }
    }
}