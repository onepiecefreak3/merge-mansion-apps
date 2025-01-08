using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(2)]
    public class DeprecatedMailType2 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType2()
        {
        }
    }
}