using Metaplay.Core.Model;
using System;

namespace GameLogic
{
    [MetaSerializableDerived(2)]
    public class IntArg : SerializableArg<int>
    {
        private IntArg()
        {
        }

        public IntArg(int value)
        {
        }
    }
}