using System;
using GameLogic.Config;

namespace Metaplay.Core.Config
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
