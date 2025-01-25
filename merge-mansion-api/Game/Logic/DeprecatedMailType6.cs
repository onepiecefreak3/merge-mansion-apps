using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaSerializableDerived(6)]
    [MetaFormDeprecated]
    public class DeprecatedMailType6 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType6()
        {
        }
    }
}