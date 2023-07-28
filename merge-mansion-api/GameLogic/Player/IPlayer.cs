using System.Collections.Generic;
using Game.Logic;
using GameLogic.Player.Board;
using GameLogic.Random;

namespace GameLogic.Player
{
    public interface IPlayer : IGenerationContext
    {
        SpawnFactoryState SpawnFactoryState { get; }

        // TODO: Import player board
        IEnumerable<IBoard> Boards { get; }
    }
}
