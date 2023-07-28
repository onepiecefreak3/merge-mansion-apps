using System;

namespace Metaplay.Core.Config
{
    public class EmptyGameConfigDataResolver : IGameConfigDataResolver
    {
        public static readonly EmptyGameConfigDataResolver Instance = new EmptyGameConfigDataResolver();
        public object TryResolveReference(Type type, object configKey)
        {
            throw new NotImplementedException();
        }
    }
}
