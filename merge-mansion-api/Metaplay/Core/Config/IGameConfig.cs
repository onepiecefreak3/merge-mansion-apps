using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfig : IGameConfigDataResolver, IGameConfigDataRegistry
    {
        ContentHash ArchiveVersion { get; }

        void Import(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver);
        bool AllowReferenceResolverUpdate { get; set; }
    //void BuildTimeValidate(GameConfigBuildWarnings.VariantWarnings variantWarnings);
    }
}