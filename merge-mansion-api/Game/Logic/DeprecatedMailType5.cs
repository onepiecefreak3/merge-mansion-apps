using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaSerializableDerived(5)]
    [MetaFormDeprecated]
    public class DeprecatedMailType5 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType5()
        {
        }
    }
}