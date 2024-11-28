using Metaplay.Core.Model;

namespace Game.Cloud.Config
{
    [MetaSerializable]
    public abstract class ConfigDefinition<TKeyObject, TValueObject>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public TKeyObject ConfigKey { get; set; }

        protected ConfigDefinition()
        {
        }

        public ConfigDefinition(TKeyObject key)
        {
        }
    }
}