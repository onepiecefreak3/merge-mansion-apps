using Metaplay.Core.Model;
using System;
using GameLogic.Player.Director.Conditions;
using GameLogic.Player.Director.Actions;

namespace GameLogic.Player.Director
{
    [MetaSerializable]
    public class ScriptedEvent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private IScriptedEventCondition Condition { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private ISerializedAction Action { get; set; }

        private ScriptedEvent()
        {
        }

        public ScriptedEvent(int id, IScriptedEventCondition condition, ISerializedAction action)
        {
        }
    }
}