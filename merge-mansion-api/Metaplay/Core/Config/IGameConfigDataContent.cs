using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigDataContent
    {
        object ConfigDataObject { get; }
    }
}