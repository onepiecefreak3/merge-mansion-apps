using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Director.Config
{
    [MetaSerializable]
    public interface IDirectorAction
    {
        bool IsVisualAction { get; }
    }
}