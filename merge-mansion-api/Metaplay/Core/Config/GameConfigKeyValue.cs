using Metaplay.Core.Serialization;
using Metaplay.Generated;
using static Metaplay.Core.Network.MessageTransport;

namespace Metaplay.Core.Config
{
    public class GameConfigKeyValue<TKeyValue> : GameConfigKeyValue
    {
        public GameConfigKeyValue()
        {
        }
    }

    public abstract class GameConfigKeyValue : IGameConfigEntry, IGameConfigMember
    {
        protected GameConfigKeyValue()
        {
        }

        public void ResolveMetaRefs(IGameConfigDataResolver resolver)
        {
            object keyValue = this;
            MetaSerialization.ResolveMetaRefs(GetType(), ref keyValue, resolver);
        }

        public virtual void PostLoad()
        {
            throw new System.NotImplementedException();
        }

        public void BuildTimeValidate()
        {
            throw new System.NotImplementedException();
        }
    }
}