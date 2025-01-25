using Metaplay.Core.Model;
using System;

namespace GameLogic
{
    [MetaSerializableDerived(8)]
    public class BoolArg : SerializableArg<bool>
    {
        private BoolArg()
        {
        }

        public BoolArg(bool value)
        {
        }
    }
}