using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Director.Config
{
    [MetaSerializableDerived(4)]
    public class TriggerDialogue : IDirectorAction
    {
        [MetaMember(1, 0)]
        public StoryDefinitionId DialogueId { get; set; }
    }
}
