using System;

namespace Metaplay.Metaplay.Core.Config
{
    public interface IGameConfigDataRegistry
    {
        void RegisterReferenceResolver(Type type, Func<object, object> tryResolveFunc);
    }
}
