using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(100)]
    public class DefaultGameConfigBuildParameters : GameConfigBuildParameters
    {
        public override bool IsIncremental { get; }

        public DefaultGameConfigBuildParameters()
        {
        }
    }
}