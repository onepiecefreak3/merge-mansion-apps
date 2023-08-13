using GameLogic.Story;
using Metaplay.Core.Model;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(4)]
    public class TriggerDialogue : IDirectorAction
    {
        [MetaMember(1, 0)]
        public StoryDefinitionId DialogueId { get; set; }
        public StoryDefinitionId StoryDefinitionId { get; }

        private TriggerDialogue()
        {
        }

        public TriggerDialogue(StoryDefinitionId dialogueId)
        {
        }
    }
}