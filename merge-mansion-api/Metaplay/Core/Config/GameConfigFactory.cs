using System;

namespace Metaplay.Metaplay.Core.Config
{
    public class GameConfigFactory : IMetaIntegrationSingleton<GameConfigFactory>
    {
        public static GameConfigFactory Instance => IntegrationRegistry.Get<GameConfigFactory>();

        public virtual ISharedGameConfig ImportSharedGameConfig(PatchedConfigArchive archive)
        {
            var configType = GameConfigRepository.Instance.SharedGameConfigType;
            var configInst = (ISharedGameConfig)Activator.CreateInstance(configType);

            configInst.Import(archive, EmptyGameConfigDataResolver.Instance);

            return configInst;
        }
    }
}
