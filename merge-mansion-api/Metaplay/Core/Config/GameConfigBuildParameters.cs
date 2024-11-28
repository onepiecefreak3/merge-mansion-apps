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

        [MetaValidateRequired]
        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaFormExcludeDerivedType(new string[] { "Game.Cloud.Localization.GridlyBuildSource" })]
        [MetaFormLayoutOrderHint(-1)]
        public GameConfigBuildSource DefaultSource;
    }
}