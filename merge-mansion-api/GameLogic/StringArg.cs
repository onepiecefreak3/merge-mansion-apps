using Metaplay.Core.Model;
using System;

namespace GameLogic
{
    [MetaSerializableDerived(1)]
    public class StringArg : SerializableArg<string>
    {
        private StringArg()
        {
        }

        public StringArg(string value)
        {
        }
    }
}