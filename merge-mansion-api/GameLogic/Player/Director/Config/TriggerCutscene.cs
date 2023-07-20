using Metaplay.GameLogic.Cutscenes;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(13)]
    [MetaSerializable]
    public class TriggerCutscene : IDirectorAction
    {
        [MetaMember(1, 0)]
        private CutsceneId CutsceneId { get; set; }
    }
}
