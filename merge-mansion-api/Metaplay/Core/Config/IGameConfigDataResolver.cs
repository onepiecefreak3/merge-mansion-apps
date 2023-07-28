using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigDataResolver
    {
        object TryResolveReference(Type type, object configKey);
    }
}
