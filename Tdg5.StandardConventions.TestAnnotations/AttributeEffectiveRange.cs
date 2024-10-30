using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Data object capturing the details of an attribute and its effective range.
/// </summary>
public class AttributeEffectiveRange
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AttributeEffectiveRange"/> class.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <param name="filePath">The file path of the syntax object that the
    /// attribute applies to.</param>
    /// <param name="startLine">The starting line number of the syntax object
    /// that the attribute applies to.</param>
    /// <param name="endLine">The ending line number of the syntax object that
    /// the attribute applies to.</param>
    public AttributeEffectiveRange(
        AttributeSyntax attribute, string filePath, int startLine, int endLine)
    {
        this.Attribute = attribute;
        this.EndLine = endLine;
        this.FilePath = filePath;
        this.StartLine = startLine;
    }

    /// <summary>
    /// Gets the attribute.
    /// </summary>
    public AttributeSyntax Attribute { get; }

    /// <summary>
    /// Gets the ending line number of the syntax object that the attribute
    /// applies to.
    /// </summary>
    public int EndLine { get; }

    /// <summary>
    /// Gets the file path of the syntax object that the attribute applies to.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Gets the starting line number of the syntax object that the attribute
    /// applies to.
    /// </summary>
    public int StartLine { get; }
}
