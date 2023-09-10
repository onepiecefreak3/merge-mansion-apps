using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1013)]
    public class PlayerPropertyLastLoginClientVersion : TypedPlayerPropertyId<string>
    {
        public override string DisplayName => "Last Checked Game Version";

        public PlayerPropertyLastLoginClientVersion()
        {
        }
    }
}