using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Codex
{
    [MetaSerializable]
    public class CodexCategoryInfo : IGameConfigData<CodexCategoryId>, IGameConfigData, IHasGameConfigKey<CodexCategoryId>
    {
        [MetaMember(1, 0)]
        public CodexCategoryId ConfigKey { get; set; }

        [MetaMember(2, 0)]
        public MetaRef<ItemDefinition> IconItem { get; set; }

        public CodexCategoryInfo()
        {
        }

        public CodexCategoryInfo(CodexCategoryId configKey, MetaRef<ItemDefinition> iconItem)
        {
        }
    }
}