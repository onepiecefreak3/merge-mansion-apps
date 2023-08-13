using GameLogic.Cutscenes;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(13)]
    public class TriggerCutscene : IDirectorAction
    {
        [MetaMember(1, 0)]
        private CutsceneId CutsceneId { get; set; }

        private TriggerCutscene()
        {
        }

        public TriggerCutscene(CutsceneId cutsceneId)
        {
        }
    }
}