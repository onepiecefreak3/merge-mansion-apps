using Metaplay.Core.Model;
using GameLogic.Story;

namespace GameLogic.Player.Director.Actions
{
    [MetaSerializableDerived(2)]
    public class TriggerDialogueSerializedAction : ISerializedAction
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private StoryDefinitionId StoryDefinitionId { get; set; }

        private TriggerDialogueSerializedAction()
        {
        }

        public TriggerDialogueSerializedAction(StoryDefinitionId storyDefinitionId)
        {
            StoryDefinitionId = storyDefinitionId;
        }
    }
}