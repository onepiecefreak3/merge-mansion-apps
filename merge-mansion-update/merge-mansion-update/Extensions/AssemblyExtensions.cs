using Mono.Cecil;

namespace merge_mansion_update.Extensions
{
    static class AssemblyExtensions
    {
        public static AssemblyDefinition? GetAssembly(this IList<AssemblyDefinition> assemblies, string assemblyName)
        {
            return assemblies.FirstOrDefault(x => x.Name.Name == assemblyName);
        }

        public static TypeDefinition? GetType(this AssemblyDefinition assembly, string typeName)
        {
            return assembly.MainModule.Types.FirstOrDefault(x => x.Name == typeName);
        }
    }
}
