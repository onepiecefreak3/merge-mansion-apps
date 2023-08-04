using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    [MetaReservedMembers(100, 199)]
    public abstract class GameConfigBuildParameters
    {
        public abstract bool IsIncremental { get; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public ConfigValidationType ConfigValidationType { get; set; }

        protected GameConfigBuildParameters()
        {
        }
    }
}