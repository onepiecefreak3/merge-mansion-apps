using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Game.Logic;
using Metaplay.GameLogic.Player.Board;
using Metaplay.GameLogic.Random;

namespace Metaplay.GameLogic.Player
{
    public interface IPlayer : IGenerationContext
    {
        SpawnFactoryState SpawnFactoryState { get; }

        // TODO: Import player board
        IEnumerable<IBoard> Boards { get; }
    }
}
