using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1009)]
    public class PlayerPropertySelectedLanguage : TypedPlayerPropertyId<string>
    {
        public override string DisplayName => "Selected language";

        public PlayerPropertySelectedLanguage()
        {
        }
    }
}