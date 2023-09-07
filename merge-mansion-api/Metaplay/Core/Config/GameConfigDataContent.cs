using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    public struct GameConfigDataContent<TConfigData>
    {
        [MetaMember(1)]
        public TConfigData ConfigData { get; set; }

        public GameConfigDataContent(TConfigData configData)
        {
            ConfigData = configData;
        }
    }
}