using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Merging
{
    [MetaSerializable]
    public class XpState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Experience { get; set; }

        public XpState()
        {
        }
    }
}