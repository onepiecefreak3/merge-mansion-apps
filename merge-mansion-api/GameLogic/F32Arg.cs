using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic
{
    [MetaSerializableDerived(3)]
    public class F32Arg : SerializableArg<F32>
    {
        private F32Arg()
        {
        }

        public F32Arg(F32 value)
        {
        }
    }
}