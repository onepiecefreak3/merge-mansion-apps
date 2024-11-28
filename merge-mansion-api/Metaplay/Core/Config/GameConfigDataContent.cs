using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    public struct GameConfigDataContent<TConfigData> : IGameConfigDataContent
    {
        public TConfigData ConfigData { get; set; }

        public GameConfigDataContent(TConfigData configData)
        {
            ConfigData = configData;
        }

        object Metaplay.Core.Config.IGameConfigDataContent.ConfigDataObject { get; }
    }
}