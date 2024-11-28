using System.Diagnostics.CodeAnalysis;

// This suppression is intentionally invalid and should cause an IDE0076 warning.
[assembly: SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:Elements should be documented",
    Justification = "Intentionally broken",
    Scope = "member",
    Target = "~M:ProjectScopedExpectations.Method")]
