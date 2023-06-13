using merge_mansion_update.Extensions;
using merge_mansion_update.Il2CppBinary;
using merge_mansion_update.Il2CppBinary.Utils;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mono.Cecil;
using Microsoft.CodeAnalysis;

Loader.Load("libil2cpp.so", "global-metadata.dat", out var metadata, out var il2Cpp);

var assemblies = new DummyAssemblyGenerator(new Il2CppExecutor(metadata, il2Cpp)).Assemblies;

var metaplayAssembly = assemblies.GetAssembly("GameLogic");
var sharedGameConfig = metaplayAssembly.GetType("SharedGameConfig");

var rootPath = @"D:\Users\Kirito\Desktop\Mobile Projects\MergeMansion\Projects\merge-mansion-apps\merge-mansion-apps\merge-mansion-api";
var nameSpacePrefix = "Metaplay.";

// Compare and update SharedGameConfig
MergeSharedGameConfig(rootPath, sharedGameConfig, nameSpacePrefix);

static void MergeSharedGameConfig(string rootPath, TypeDefinition? sharedGameConfigType, string nameSpacePrefix)
{
    // Prepare data
    var sharedGameConfigPath = Path.Combine(rootPath, sharedGameConfigType.GetPath());
    var rootNode = CSharpSyntaxTree.ParseText(File.ReadAllText(sharedGameConfigPath)).GetCompilationUnitRoot();
    var gameConfigClass = rootNode.DescendantNodes().OfType<ClassDeclarationSyntax>().First();

    // Modify and add new properties
    var gameConfigProperties = gameConfigClass.DescendantNodes().OfType<PropertyDeclarationSyntax>().Where(pd => (pd.Type as GenericNameSyntax).Identifier.Text.StartsWith("GameConfigLibrary")).ToArray();
    var newProperties = sharedGameConfigType.Properties.Where(pd => gameConfigProperties.All(x => x.Identifier.Text != pd.Name) && pd.PropertyType.Name.StartsWith("GameConfigLibrary")).ToArray();

    var newPropertyNodes = newProperties.Select(np => (MemberDeclarationSyntax)CreatePropertyDeclaration(np.PropertyType, np.Name)).ToArray();
    var newClassNode = gameConfigClass.AddMembers(newPropertyNodes);
    rootNode = rootNode.ReplaceNode(gameConfigClass, newClassNode);

    // Add missing using directives
    //var nameSpaces = newProperties.SelectMany(x => x.PropertyType.GetNamespaces()).Distinct();
    //rootNode = rootNode.AddUsings(nameSpaces.Select(x => CreateUsingDirective(x, nameSpacePrefix)).Where(x => x != null).ToArray()!);

    // Write changed SharedGameConfig
    rootNode.WriteTo(new StreamWriter(File.OpenWrite(sharedGameConfigPath)));
}

static PropertyDeclarationSyntax CreatePropertyDeclaration(TypeReference type, string name)
{
    var propertyNode = SyntaxFactory
        .PropertyDeclaration(SyntaxFactory.ParseTypeName(type.GetTypeName())/*.WithTrailingTrivia(SyntaxFactory.Whitespace(" "))*/, name)
        .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword).WithTrailingTrivia(SyntaxFactory.Whitespace(" "))))
        .WithAccessorList(SyntaxFactory.AccessorList().AddAccessors(
            SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))/*.WithLeadingTrivia(SyntaxFactory.Whitespace(" ")).WithTrailingTrivia(SyntaxFactory.Whitespace(" "))*/,
            SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken))/*.WithTrailingTrivia(SyntaxFactory.Whitespace(" "))*/)
            /*.WithTrailingTrivia(SyntaxFactory.Whitespace(" "))*/)
        .NormalizeWhitespace();
    //.WithLeadingTrivia(SyntaxFactory.Whitespace(Environment.NewLine + "\t\t"))
    //.WithTrailingTrivia(SyntaxFactory.Whitespace(Environment.NewLine));
    return propertyNode;
}

static UsingDirectiveSyntax? CreateUsingDirective(string name, string nameSpacePrefix)
{
    if (name.StartsWith("System"))
        return null;

    return SyntaxFactory
        .UsingDirective(SyntaxFactory.IdentifierName(nameSpacePrefix + name).WithLeadingTrivia(SyntaxFactory.Whitespace(" ")))
        .WithTrailingTrivia(SyntaxFactory.Whitespace(Environment.NewLine));
}