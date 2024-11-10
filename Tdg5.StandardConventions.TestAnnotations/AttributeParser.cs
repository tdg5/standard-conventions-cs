using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics.CodeAnalysis;

namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Helper class to build attributes from <see cref="AttributeSyntax"/>.
/// </summary>
public static class AttributeParser
{
    /// <summary>
    /// Parses the given <see cref="AttributeWithEffectiveRange"/> into an instance of
    /// <see cref="ICodeAnalysisViolationExpectation"/>.
    /// </summary>
    /// <param name="attributeWithEffectiveRange">The attribute with effective
    /// range.</param>
    /// <returns>The parsed instance of <see
    /// cref="ICodeAnalysisViolationExpectation"/> or null if the attribute
    /// could not be parsed.</returns>
    internal static ICodeAnalysisViolationExpectation? TryParse(
        AttributeWithEffectiveRange attributeWithEffectiveRange)
    {
        var attributeArguments = ParseAttributeArguments(attributeWithEffectiveRange);
        if (!TryGetAttributeName(attributeWithEffectiveRange.Attribute, out var attributeName))
        {
            return null;
        }

        return attributeName switch
        {
            nameof(CodeAnalysisViolationExpectedAttribute) =>
                CodeAnalysisViolationExpectedAttribute.GetExpecation(attributeArguments),
            nameof(FileAnalysisViolationExpectedAttribute) =>
                FileAnalysisViolationExpectedAttribute.GetExpecation(attributeArguments),
            nameof(ProjectAnalysisViolationExpectedAttribute) =>
                ProjectAnalysisViolationExpectedAttribute.GetExpecation(attributeArguments),
            _ => throw new InvalidOperationException(
                $"Cannot parse {attributeName} attribute."),
        };
    }

    /// <summary>
    /// Parses the given <see cref="AttributeSyntax"/> into a <see
    /// cref="CodeAnalysisViolationExpectation"/>.
    /// </summary>
    /// <param name="attributeWithEffectiveRange">An <see
    /// cref="AttributeWithEffectiveRange"/> representation of a <see
    /// cref="CodeAnalysisViolationExpectedAttribute"/> to parse.</param>
    /// <returns>An instance of <see cref="CodeAnalysisViolationExpectation"/>
    /// representing the parsed attribute.</returns>
    private static AttributeArguments ParseAttributeArguments(
        AttributeWithEffectiveRange attributeWithEffectiveRange)
    {
        var attribute = attributeWithEffectiveRange.Attribute;
        var argumentList = attribute.ArgumentList
            ?? throw new InvalidOperationException(
                $"Cannot parse {attribute}, argument list is missing.");

        var positionalArguments = new List<object>();
        var namedArguments = new Dictionary<string, object>();
        foreach (var argument in argumentList.Arguments)
        {
            var expressionLiteral = argument.Expression as LiteralExpressionSyntax
                ?? throw new InvalidOperationException(
                    $"Cannot parse {argument.Expression} as a literal expression.");
            var expressionValue = expressionLiteral.Token.Value
                ?? throw new InvalidOperationException(
                    $"Cannot parse {expressionLiteral.Token} as a literal value.");

            if (argument.NameColon?.Name is IdentifierNameSyntax argumentName)
            {
                namedArguments.Add(
                    argumentName.Identifier.Text, expressionValue);
            }
            else
            {
                positionalArguments.Add(expressionValue);
            }
        }

        return new(attributeWithEffectiveRange, positionalArguments, namedArguments);
    }

    private static bool TryGetAttributeName(
        AttributeSyntax attribute, [MaybeNullWhen(false)] out string attributeName)
    {
        SyntaxToken? identifier = null;

        if (attribute.Name is IdentifierNameSyntax identifierName)
        {
            identifier = identifierName.Identifier;
        }

        if (attribute.Name is QualifiedNameSyntax qualifiedName)
        {
            identifier = qualifiedName.Right.Identifier;
        }

        if (attribute.Name is AliasQualifiedNameSyntax aliasQualifiedName)
        {
            identifier = aliasQualifiedName.Name.Identifier;
        }

        if (identifier is null)
        {
            attributeName = null!;
            return false;
        }

        string identifierText = identifier.Value.Text;
        attributeName = identifierText.EndsWith("Attribute")
            ? identifierText
            : $"{identifierText}Attribute";
        return true;
    }
}
