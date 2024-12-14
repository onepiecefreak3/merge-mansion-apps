using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    [MetaReservedMembers(101, 200)]
    public abstract class GameConfigBuildParameters : IMetaIntegration<GameConfigBuildParameters>, IMetaIntegration, IGameDataBuildParameters
    {
        public abstract bool IsIncremental { get; }

        protected GameConfigBuildParameters()
        {
        }

        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        [MetaFormLayoutOrderHint(-1)]
        [MetaFormExcludeDerivedType(new string[] { "Game.Cloud.Localization.GridlyBuildSource" })]
        public GameConfigBuildSource DefaultSource;
    }
}