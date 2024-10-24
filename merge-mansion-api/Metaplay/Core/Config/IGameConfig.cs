using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfig : IGameConfigDataResolver
    {
        void Import(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver);
        int SpecializationSpecificDuplicationAmount { get; }

        ContentHash ArchiveVersion { get; }
    //void BuildTimeValidate(GameConfigBuildWarnings.VariantWarnings variantWarnings);
    }
}