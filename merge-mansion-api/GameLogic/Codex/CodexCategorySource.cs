using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Codex
{
    public class CodexCategorySource : IConfigItemSource<CodexCategoryInfo, CodexCategoryId>, IGameConfigSourceItem<CodexCategoryId, CodexCategoryInfo>, IHasGameConfigKey<CodexCategoryId>
    {
        public CodexCategoryId ConfigKey { get; set; }
        private string IconItem { get; set; }

        public CodexCategorySource()
        {
        }
    }
}