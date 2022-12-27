using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config;

namespace Metaplay.Metaplay.Core.Config
{
    public class GameConfigRepository
    {
        public static GameConfigRepository Instance { get; set; }

        // 0x18
        public Type SharedGameConfigType => typeof(SharedGameConfig);

        public GameConfigRepository()
        {
            // TODO: Implement for type properties
            //var gameConfigTypes = TypeScanner.GetOwnAssemblies().SelectMany(x => x.GetExportedTypes()).Where(x => x.IsGameConfigClass()).ToList();
            //foreach (var gameConfigType in gameConfigTypes)
            //{
            //    if (SharedGameConfigType == null)
            //        SharedGameConfigType = typeof(SharedGameConfigBase);
            //}
        }

        public static void InitializeSingleton()
        {
            Instance = new GameConfigRepository();
        }
    }
}
