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
    /// Determines whether the specified attribute is supported.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <returns>True if the attribute is supported; otherwise, false.</returns>
    public static bool IsSupportedAttribute(AttributeSyntax attribute)
    {
        if (!TryGetAttributeName(attribute, out var attributeName))
        {
            return false;
        }

        return attributeName switch
        {
            nameof(CodeAnalysisViolationExpectedAttribute) => true,
            _ => false,
        };
    }

    /// <summary>
    /// Parses the given <see cref="AttributeEffectiveRange"/> into an instance of
    /// <see cref="ICodeAnalysisViolationExpectation"/>.
    /// </summary>
    /// <param name="attributeWithEffectiveRange">The attribute with effective
    /// range.</param>
    /// <returns>An instance of <see
    /// cref="ICodeAnalysisViolationExpectation"/>.</returns>
    public static ICodeAnalysisViolationExpectation Parse(
        AttributeEffectiveRange attributeWithEffectiveRange)
    {
        if (TryGetAttributeName(attributeWithEffectiveRange.Attribute, out var attributeName))
        {
            return attributeName switch
            {
                nameof(CodeAnalysisViolationExpectedAttribute) =>
                    ParseCodeAnalysisViolationExpectation(attributeWithEffectiveRange),
                _ => throw new InvalidOperationException(
                    $"Cannot parse {attributeName} attribute."),
            };
        }

        var attributeSyntax = attributeWithEffectiveRange.Attribute;
        throw new InvalidOperationException(
            $"Cannot parse attribute from syntax {attributeSyntax}.");
    }

    /// <summary>
    /// Parses the given <see cref="AttributeSyntax"/> into a <see
    /// cref="BlockScopeCodeAnalysisViolationExpectation"/>.
    /// </summary>
    /// <param name="attributeWithEffectiveRange">An <see
    /// cref="AttributeEffectiveRange"/> representation of a <see
    /// cref="CodeAnalysisViolationExpectedAttribute"/> to parse.</param>
    /// <returns>An instance of <see cref="BlockScopeCodeAnalysisViolationExpectation"/>
    /// representing the parsed attribute.</returns>
    private static BlockScopeCodeAnalysisViolationExpectation ParseCodeAnalysisViolationExpectation(
        AttributeEffectiveRange attributeWithEffectiveRange)
    {
        var attribute = attributeWithEffectiveRange.Attribute;
        if (!TryGetAttributeName(attribute, out var attributeName) ||
            attributeName != nameof(CodeAnalysisViolationExpectedAttribute))
        {
            throw new InvalidOperationException(
                $"Cannot parse {attributeName} attribute as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)}.");
        }

        var argumentList = attribute.ArgumentList
            ?? throw new InvalidOperationException(
                $"Cannot parse {attribute}, argument list is missing.");

        if (argumentList.Arguments.Count != 2)
        {
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)},"
                + $" expected 2 arguments, found {argumentList.Arguments.Count}.");
        }

        string[] arguments = new string[2];
        int argumentIndex = 0;
        foreach (var argument in argumentList.Arguments)
        {
            var expressionLiteral = argument.Expression as LiteralExpressionSyntax
                ?? throw new InvalidOperationException(
                    $"Cannot parse {argument.Expression} as a literal expression.");
            var expressionValue = expressionLiteral.Token.Value
                ?? throw new InvalidOperationException(
                    $"Cannot parse {expressionLiteral.Token} as a literal value.");

            var argumentValueString = (string)expressionValue;

            if (argument.NameColon?.Name is IdentifierNameSyntax argumentName)
            {
                if (argumentName.Identifier.Text == "code")
                {
                    arguments[0] = argumentValueString;
                }
                else if (argumentName.Identifier.Text == "level")
                {
                    arguments[1] = argumentValueString;
                }
            }
            else
            {
                arguments[argumentIndex] = argumentValueString;
            }

            argumentIndex++;
        }

        string code = arguments[0] ??
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)}, {nameof(code)}"
                + " argument could not be determined.");

        string level = arguments[1] ??
            throw new InvalidOperationException(
                $"Cannot parse {attribute} as a"
                + $" {nameof(CodeAnalysisViolationExpectedAttribute)}, {nameof(level)}"
                + " argument could not be determined.");

        return new BlockScopeCodeAnalysisViolationExpectation(
            code,
            level,
            attributeWithEffectiveRange.FilePath,
            attributeWithEffectiveRange.StartLine,
            attributeWithEffectiveRange.EndLine);
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
