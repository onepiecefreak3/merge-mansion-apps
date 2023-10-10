using Metaplay.Core.Model;

namespace GameLogic
{
    public abstract class SerializableArg<T> : ISerializableArg
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public T Value { get; set; }

        protected SerializableArg()
        {
        }

        protected SerializableArg(T value)
        {
        }
    }
}