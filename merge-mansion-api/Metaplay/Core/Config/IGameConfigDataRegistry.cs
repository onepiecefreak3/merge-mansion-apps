using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigDataRegistry
    {
        void RegisterReferenceResolver(Type type, Func<object, object> tryResolveFunc);
    }
}