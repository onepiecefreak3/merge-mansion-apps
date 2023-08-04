using Metaplay.Core.Model;
using GameLogic.Cutscenes;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(8)]
    public class TriggerCutsceneSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CutsceneId CutsceneId { get; set; }

        private TriggerCutsceneSerializedAction()
        {
        }

        public TriggerCutsceneSerializedAction(CutsceneId cutsceneId)
        {
        }
    }
}