using System;

namespace Metaplay.Metaplay.Core.Config
{
    public static class GameConfigDataResolverExtensions
    {
        public static object ResolveReference(this IGameConfigDataResolver resolver, Type type, object configKey)
        {
            var reference = resolver.TryResolveReference(type, configKey);
            if (reference == null)
                throw new InvalidOperationException($"Failed to resolve config data reference to '{configKey.GetType()}' of type {type}");

            return reference;
        }
    }
}
