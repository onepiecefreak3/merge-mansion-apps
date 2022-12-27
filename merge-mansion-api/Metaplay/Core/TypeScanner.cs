using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metaplay.Metaplay.Core
{
    public static class TypeScanner
    {
        public static List<Assembly> GetOwnAssemblies()
        {
            var result = new List<Assembly>();

            var exclude = new[]
            {
                "System", "Microsoft", "Unity", "Google", "Facebook", "Mono", "Akka", "Newtonsoft", "Prometheus",
                "Serilog", "mscorlib", "netstandard", "nunit", "Firebase"
            };
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
                if (exclude.All(e => !assembly.FullName.StartsWith(e)))
                    result.Add(assembly);

            return result;
        }

        public static IEnumerable<Type> GetAllTypes()
        {
            return GetOwnAssemblies().SelectMany(x => x.ExportedTypes);
        }

        public static IEnumerable<Type> GetClassesWithAttribute<TAttribute>() where TAttribute : Attribute
        {
            return GetAllTypes().Where(x => x.GetCustomAttribute<TAttribute>() != null);
        }
    }
}
