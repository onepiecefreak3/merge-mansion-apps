using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Actions.Basic
{
    [ModelAction(11004)]
    public class DirectorTryMakeReadyForActivation : PlayerAction
    {
        private static Dictionary<DirectorTryMakeReadyForActivation.DirectorActivationEventId, DirectorTryMakeReadyForActivation.DirectorActivationEventDefinition> definitions;
        private DirectorTryMakeReadyForActivation.DirectorActivationEventId EventId { get; set; }

        private DirectorTryMakeReadyForActivation()
        {
        }

        public DirectorTryMakeReadyForActivation(DirectorTryMakeReadyForActivation.DirectorActivationEventId id)
        {
        }

        [MetaSerializable]
        public enum DirectorActivationEventId
        {
            FirstToolBarrelActivation = 0,
            SecondToolBarrelActivation = 1
        }

        public readonly struct DirectorActivationEventDefinition
        {
            public readonly Func<PlayerModel, bool, MetaActionResult> Operation;
        }
    }
}