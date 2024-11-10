using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Helper class to extract code analysis violations from a C# file.
/// </summary>
public static class ExpectationExtractor
{
    /// <summary>
    /// Extracts the code analysis violation expectations from the specified
    /// file.
    /// </summary>
    /// <param name="projectPath">The path of the project to extract the
    /// expectations from.</param>
    /// <param name="filePath">The path of the file to extract the expectations
    /// from.</param>
    /// <returns>The list of code analysis violation expectations.</returns>
    public static List<ICodeAnalysisViolationExpectation> ExtractExpectations(
        string projectPath,
        string filePath)
    {
        string code = File.ReadAllText(filePath);
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
        var descendentNodes = root.DescendantNodes();

        // Find all the member types that we care about attributes for.
        List<MemberDeclarationSyntax> memberDeclarations = [
            .. descendentNodes.OfType<ClassDeclarationSyntax>(),
            .. descendentNodes.OfType<ConstructorDeclarationSyntax>(),
            .. descendentNodes.OfType<DelegateDeclarationSyntax>(),
            .. descendentNodes.OfType<EnumDeclarationSyntax>(),
            .. descendentNodes.OfType<EventDeclarationSyntax>(),
            .. descendentNodes.OfType<FieldDeclarationSyntax>(),
            .. descendentNodes.OfType<InterfaceDeclarationSyntax>(),
            .. descendentNodes.OfType<MethodDeclarationSyntax>(),
            .. descendentNodes.OfType<PropertyDeclarationSyntax>(),
            .. descendentNodes.OfType<StructDeclarationSyntax>(),
        ];

        List<AttributeWithEffectiveRange> candidateAttributes = [];
        foreach (var memberDeclaration in memberDeclarations)
        {
            var memberAttributes =
                memberDeclaration.AttributeLists.SelectMany(al => al.Attributes);
            foreach (var attribute in memberAttributes)
            {
                var lineSpan = memberDeclaration.GetLocation().GetLineSpan();
                var startLine = lineSpan.StartLinePosition.Line + 1;
                var endLine = lineSpan.EndLinePosition.Line + 1;
                candidateAttributes.Add(
                    new(attribute, projectPath, filePath, startLine, endLine));
            }
        }

        return candidateAttributes
            .Select(candidate => AttributeParser.TryParse(candidate)!)
            .Where(_ => _ is not null)
            .ToList();
    }
}
