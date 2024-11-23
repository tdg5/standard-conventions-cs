using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Tdg5.StandardConventions.TestAnnotations;

/// <summary>
/// Data object capturing the details of an attribute and its effective range.
/// </summary>
internal class AttributeWithEffectiveRange
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AttributeWithEffectiveRange"/> class.
    /// </summary>
    /// <param name="attribute">The attribute.</param>
    /// <param name="projectPath">The project path of the syntax object that the
    /// attribute applies to.</param>
    /// <param name="filePath">The file path of the syntax object that the
    /// attribute applies to.</param>
    /// <param name="startLine">The starting line number of the syntax object
    /// that the attribute applies to.</param>
    /// <param name="endLine">The ending line number of the syntax object that
    /// the attribute applies to.</param>
    public AttributeWithEffectiveRange(
        AttributeSyntax attribute,
        string projectPath,
        string filePath,
        int? startLine,
        int? endLine)
    {
        Attribute = attribute;
        EndLine = endLine;
        FilePath = filePath;
        ProjectPath = projectPath;
        StartLine = startLine;
    }

    /// <summary>
    /// Gets the attribute.
    /// </summary>
    public AttributeSyntax Attribute { get; }

    /// <summary>
    /// Gets the ending line number of the syntax object that the attribute
    /// applies to.
    /// </summary>
    public int? EndLine { get; }

    /// <summary>
    /// Gets the file path of the syntax object that the attribute applies to.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Gets the project path of the syntax object that the attribute applies
    /// to.
    /// </summary>
    public string ProjectPath { get; }

    /// <summary>
    /// Gets the starting line number of the syntax object that the attribute
    /// applies to.
    /// </summary>
    public int? StartLine { get; }
}
