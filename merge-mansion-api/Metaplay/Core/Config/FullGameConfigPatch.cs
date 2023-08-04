using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableTypeProvider]
    public class FullGameConfigPatch
    {
        public GameConfigPatch SharedConfigPatch { get; set; }
        public GameConfigPatch ServerConfigPatch { get; set; }
        public bool IsEmpty { get; }

        public FullGameConfigPatch(GameConfigPatch sharedConfigPatch, GameConfigPatch serverConfigPatch)
        {
        }
    }
}