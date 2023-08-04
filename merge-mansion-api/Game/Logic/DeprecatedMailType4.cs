using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(4)]
    public class DeprecatedMailType4 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType4()
        {
        }
    }
}