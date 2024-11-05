using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Tdg5.StandardConventions.TestAnnotations;

public static class Analyzer
{
    public static List<BlockScopeCodeAnalysisViolationExpectation> Analyze(string filePath)
    {
        // Read the file content
        string code = File.ReadAllText(filePath);

        // Parse the code into a syntax tree
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        var descendentNodes = root.DescendantNodes();
        List<MemberDeclarationSyntax> memberDeclarations = [
            ..descendentNodes.OfType<ClassDeclarationSyntax>(),
            ..descendentNodes.OfType<ConstructorDeclarationSyntax>(),
            ..descendentNodes.OfType<DelegateDeclarationSyntax>(),
            ..descendentNodes.OfType<EnumDeclarationSyntax>(),
            ..descendentNodes.OfType<EventDeclarationSyntax>(),
            ..descendentNodes.OfType<FieldDeclarationSyntax>(),
            ..descendentNodes.OfType<InterfaceDeclarationSyntax>(),
            ..descendentNodes.OfType<MethodDeclarationSyntax>(),
            ..descendentNodes.OfType<PropertyDeclarationSyntax>(),
            ..descendentNodes.OfType<StructDeclarationSyntax>(),
        ];

        List<AttributeEffectiveRange> candidateAttributes = [];
        foreach (var memberDeclaration in memberDeclarations)
        {
            var memberAttributes =
                memberDeclaration.AttributeLists.SelectMany(al => al.Attributes);
            foreach (var attribute in memberAttributes)
            {
                if (!AttributeParser.IsSupportedAttribute(attribute))
                {
                    continue;
                }

                var lineSpan = memberDeclaration.GetLocation().GetLineSpan();
                var startLine = lineSpan.StartLinePosition.Line + 1;
                var endLine = lineSpan.EndLinePosition.Line + 1;
                candidateAttributes.Add(new(attribute, filePath, startLine, endLine));
            }
        }

        return candidateAttributes
            .Select(AttributeParser.ParseCodeAnalysisViolationExpectation)
            .ToList();
    }
}
