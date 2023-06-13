using Mono.Cecil;

namespace merge_mansion_update.Extensions
{
    static class TypeExtensions
    {
        private static IDictionary<string, string> SystemTypesLookup = new Dictionary<string, string>
        {
            ["System.Void"] = "void",
            ["System.Object"] = "object",
            ["System.Bool"] = "bool",
            ["System.Byte"] = "byte",
            ["System.String"] = "string",
            ["System.Int16"] = "short",
            ["System.UInt16"] = "ushort",
            ["System.Int32"] = "int",
            ["System.UInt32"] = "uint",
            ["System.Int64"] = "long",
            ["System.UInt64"] = "ulong",
            ["System.IntPtr"] = "nint",
            ["System.UIntPtr"] = "nuint"
        };

        public static string GetPath(this TypeDefinition? type)
        {
            if (type.DeclaringType != null)
                return null;

            var nameSpacePath = type.Namespace?.Replace(".", "\\");
            var typePath = type.Name.Split('`')[0] + ".cs";

            if (nameSpacePath != null)
                return Path.Combine(nameSpacePath, typePath);

            return typePath;
        }

        public static string GetTypeName(this TypeReference type)
        {
            var typeName = type.Name;
            if (SystemTypesLookup.TryGetValue(type.Namespace + "." + type.Name, out var typeKeyword))
                typeName = typeKeyword;

            if (type is not GenericInstanceType git)
                return typeName;

            typeName = typeName.Split("`")[0];

            var genericArguments = git.GenericArguments;
            if (genericArguments.Count > 0)
                typeName += "<" + string.Join(", ", genericArguments.Select(gt => gt.GetTypeName())) + ">";

            return typeName;
        }

        public static IList<string> GetNamespaces(this TypeReference type)
        {
            var nameSpaces = new List<string>();

            if (!string.IsNullOrEmpty(type.Namespace))
                nameSpaces.Add(type.Namespace);

            if (type is not GenericInstanceType git)
                return nameSpaces;

            var genericArguments = git.GenericArguments;
            foreach (var genericArgument in genericArguments)
                nameSpaces.AddRange(genericArgument.GetNamespaces());

            return nameSpaces;
        }
    }
}
