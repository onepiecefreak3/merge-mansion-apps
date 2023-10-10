using Metaplay.Core.Config;
using System;

namespace Metaplay.Core.Activables
{
    public interface IMetaActivableConfigData<TKey> : IMetaActivableConfigData, IGameConfigData, IMetaActivableInfo, IGameConfigData<TKey>, IGameConfigKey<TKey>, IMetaActivableInfo<TKey>
    {
    }

    public interface IMetaActivableConfigData : IGameConfigData, IMetaActivableInfo
    {
        string DisplayName { get; }

        string Description { get; }

        string DisplayShortInfo { get; }
    }
}