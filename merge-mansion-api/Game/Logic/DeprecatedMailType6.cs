using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(6)]
    public class DeprecatedMailType6 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType6()
        {
        }
    }
}