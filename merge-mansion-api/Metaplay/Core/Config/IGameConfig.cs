using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfig : IGameConfigDataResolver, IGameConfigDataRegistry
    {
        ContentHash ArchiveVersion { get; }

        void Import(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver);
        bool AllowLibraryUpdate { get; set; }
    //void BuildTimeValidate(GameConfigBuildWarnings.VariantWarnings variantWarnings);
    }
}