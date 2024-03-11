using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    [MetaReservedMembers(100, 199)]
    public abstract class GameConfigBuildParameters : IMetaIntegration<GameConfigBuildParameters>, IMetaIntegration, IGameDataBuildParameters
    {
        public abstract bool IsIncremental { get; }

        protected GameConfigBuildParameters()
        {
        }

        [MetaFormLayoutOrderHint(-1)]
        [MetaValidateRequired]
        [MetaMember(101, (MetaMemberFlags)0)]
        public GameConfigBuildSource DefaultSource;
    }
}