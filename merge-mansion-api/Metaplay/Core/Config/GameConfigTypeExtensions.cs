using System;

namespace Metaplay.Core.Config
{
    public static class GameConfigTypeExtensions
    {
        public static bool IsGameConfigClass(this Type type)
        {
            if (type.ImplementsInterface(typeof(IGameConfig)))
                if (type.IsClass && !type.IsAbstract)
                    return !type.ContainsGenericParameters;

            return false;
        }
    }
}
