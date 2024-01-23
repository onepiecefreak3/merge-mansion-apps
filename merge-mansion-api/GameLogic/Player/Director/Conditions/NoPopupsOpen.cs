using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Conditions
{
    [MetaSerializableDerived(2)]
    public class NoPopupsOpen : IScriptedEventCondition
    {
        public NoPopupsOpen()
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        private bool AllowBoard { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private bool AllowCutscene { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private bool AllowHotspotCompletion { get; set; }

        public NoPopupsOpen(bool allowBoard, bool allowCutscene, bool allowHotspotCompletion)
        {
        }
    }
}