using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using Metaplay.Core.InGameMail;
using System;

namespace Game.Logic
{
    [MetaFormDeprecated]
    [MetaSerializableDerived(1)]
    public class DeprecatedMailType1 : MetaInGameMail
    {
        public override string Description { get; }

        public DeprecatedMailType1()
        {
        }
    }
}