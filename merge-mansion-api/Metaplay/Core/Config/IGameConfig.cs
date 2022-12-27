namespace Metaplay.Metaplay.Core.Config
{
    public interface IGameConfig : IGameConfigDataResolver
    {
        ContentHash ArchiveVersion { get; }

        void Import(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver);
        //void BuildTimeValidate(GameConfigBuildWarnings.VariantWarnings variantWarnings);
    }
}
