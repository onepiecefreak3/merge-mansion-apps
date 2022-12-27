using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Codex
{
    public class CodexCategoryInfo : IGameConfigData<CodexCategoryId>
    {
        [MetaMember(1, 0)]
        public CodexCategoryId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public MetaRef<ItemDefinition> IconItem { get; set; }
    }
}
