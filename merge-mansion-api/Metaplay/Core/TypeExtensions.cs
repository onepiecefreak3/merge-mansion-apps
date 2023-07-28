using System;
using System.Collections.Generic;
using System.Linq;

namespace Metaplay.Core
{
    public static class TypeExtensions
    {
        public static bool ImplementsGenericInterface(this Type type, Type genericInterfaceDefinition)
        {
            return type.GetGenericInterfaces(genericInterfaceDefinition).Any();
        }

        private static IEnumerable<Type> GetGenericInterfaces(this Type type, Type genericInterfaceDefinition)
        {
            if (!genericInterfaceDefinition.IsInterface)
                throw new ArgumentException("Expecting an interface type");

            if (!genericInterfaceDefinition.ContainsGenericParameters)
                throw new ArgumentException("Expecting a generic type definition");

            return type.GetInterfaces().Where(x => x.IsGenericTypeOf(genericInterfaceDefinition));
        }

        public static bool IsGenericTypeOf(this Type type, Type typeOf)
        {
            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == typeOf;
        }

        public static Type[] GetGenericInterfaceTypeArguments(this Type type, Type genericInterfaceDefinition)
        {
            return type.GetGenericInterface(genericInterfaceDefinition).GetGenericArguments();
        }

        public static Type GetGenericInterface(this Type type, Type genericInterfaceDefinition)
        {
            var genericInterfaces = type.GetGenericInterfaces(genericInterfaceDefinition).ToArray();
            if (genericInterfaces.Length <= 0)
                throw new InvalidOperationException("Type" + type.Name + " does not implement an interface type based on generic definition " + genericInterfaceDefinition.Name);

            if (genericInterfaces.Length != 1)
                throw new InvalidOperationException("Type " + type.Name + " implements multiple interface types based on generic definition " + genericInterfaceDefinition.Name);

            return genericInterfaces[0];
        }

        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Contains(interfaceType);
        }
    }
}
