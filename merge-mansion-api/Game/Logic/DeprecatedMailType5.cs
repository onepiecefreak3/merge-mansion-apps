using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(5)]
    public class DeprecatedMailType5 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType5()
        {
        }
    }
}