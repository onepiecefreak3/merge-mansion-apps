using merge_mansion_api.GameLogic.Cutscenes;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.Metaplay.Core.Model;

namespace merge_mansion_api.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(13)]
    public class TriggerCutscene : IDirectorAction
    {
        [MetaMember(1, 0)]
        private CutsceneId CutsceneId { get; set; }
    }
}
