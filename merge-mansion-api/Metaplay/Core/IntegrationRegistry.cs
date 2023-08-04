using System;
using System.Collections.Generic;
using System.Linq;

namespace Metaplay.Core
{
    public class IntegrationRegistry
    {
        private static IntegrationRegistry _instance; // 0x0

        private HashSet<Type> _mandatoryIntegrations; // 0x10
        private Dictionary<Type, List<Type>> _registry; // 0x18
        private Dictionary<Type, IMetaIntegrationSingleton> _singletons; // 0x20
        private Dictionary<Type, Func<IMetaIntegrationConstructible>> _constructors; // 0x28

        internal static IntegrationRegistry Instance => _instance;

        public IntegrationRegistry(Func<Type, bool> typeFilter)
        {
            _mandatoryIntegrations = new HashSet<Type>();
            _registry = new Dictionary<Type, List<Type>>();
            _singletons = new Dictionary<Type, IMetaIntegrationSingleton>();
            _constructors = new Dictionary<Type, Func<IMetaIntegrationConstructible>>();

            var ownAssemblies = TypeScanner.GetOwnAssemblies();
            var integrationTypes = ownAssemblies.SelectMany(a => a.GetExportedTypes()).Where(x => x.ImplementsGenericInterface(typeof(IMetaIntegration<>)));
            foreach (var integrationType in integrationTypes)
            {
                var intTypes = integrationType.GetGenericInterfaceTypeArguments(typeof(IMetaIntegration<>));
                foreach (var intType in intTypes.Where(typeFilter))
                {
                    // CUSTOM: To not include base classes which are their own integration
                    if (/*integrationType == intType && */integrationType.IsAbstract)
                        continue;

                    if (intType.ImplementsInterface(typeof(IRequireSingleConcreteType)))
                        _mandatoryIntegrations.Add(intType);

                    if (integrationType.IsClass && !integrationType.IsAbstract && !IsTestImplementation(intType, integrationType))
                    {
                        if (!_registry.TryGetValue(intType, out var regType))
                            _registry[intType] = new List<Type> { integrationType };
                        else
                            regType.Add(integrationType);
                    }
                }
            }

            foreach (var typePair in _registry)
            {
                var (regType, regTypes) = (typePair.Key, typePair.Value);
                var concreteType = FindSingleConcreteType(regTypes, regType);

                if (regType.ImplementsInterface(typeof(IMetaIntegrationSingleton)))
                    _singletons[regType] = (IMetaIntegrationSingleton)Activator.CreateInstance(concreteType);

                if (!regType.ImplementsInterface(typeof(IMetaIntegrationConstructible)))
                    _constructors[regType] = () => (IMetaIntegrationConstructible)Activator.CreateInstance(concreteType);
            }
        }

        public static IEnumerable<Type> MissingIntegrationTypes()
        {
            foreach (var mandType in Instance._mandatoryIntegrations)
                if (!Instance._registry.ContainsKey(mandType))
                    yield return mandType;
        }

        internal static void Init(Func<Type, bool> namespaceFilter)
        {
            _instance = new IntegrationRegistry(namespaceFilter);
        }

        public static T Get<T>()
        {
            return (T)Instance.GetSingleton(typeof(T));
        }

        public static T Create<T>()
        {
            return (T)Instance.GetConstructor(typeof(T))();
        }

        internal IMetaIntegrationSingleton GetSingleton(Type type)
        {
            if (!_singletons.TryGetValue(type, out var singleton))
                throw new InvalidOperationException($"No singleton implementation has been registered for {type}");

            return singleton;
        }

        private Func<IMetaIntegrationConstructible> GetConstructor(Type type)
        {
            if (!_constructors.TryGetValue(type, out var constructor))
                throw new InvalidOperationException($"No constructible implementation has been registered for {type}");

            return constructor;
        }

        private static bool IsTestImplementation(Type apiType, Type implType)
        {
            if (apiType.FullName != implType.FullName)
                return implType.FullName?.StartsWith("CloudCore.Tests") ?? false;

            return false;
        }

        private static Type FindSingleConcreteType(List<Type> types, Type integrationType)
        {
            var result = types[0];

            // TODO: Figure out more
            //foreach (var type in types.Skip(1))
            //    throw new InvalidOperationException($"A single implementation type is required for {integrationType}. Conflicting types were found: {result} and {type}.");

            return result;
        }
    }
}
