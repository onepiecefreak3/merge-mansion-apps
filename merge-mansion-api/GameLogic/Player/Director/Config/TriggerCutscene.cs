using GameLogic.Cutscenes;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(13)]
    public class TriggerCutscene : IDirectorAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CutsceneId CutsceneId { get; set; }

        private TriggerCutscene()
        {
        }

        public TriggerCutscene(CutsceneId cutsceneId)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}