using Metaplay.Core.Model;
using System;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Config
{
    [MetaReservedMembers(101, 200)]
    [MetaSerializable]
    public abstract class GameConfigBuildParameters : IMetaIntegration<GameConfigBuildParameters>, IMetaIntegration, IGameDataBuildParameters
    {
        public abstract bool IsIncremental { get; }

        protected GameConfigBuildParameters()
        {
        }

        [MetaFormLayoutOrderHint(-1)]
        [MetaFormExcludeDerivedType(new string[] { "Game.Cloud.Localization.GridlyBuildSource" })]
        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        public GameConfigBuildSource DefaultSource;
    }
}