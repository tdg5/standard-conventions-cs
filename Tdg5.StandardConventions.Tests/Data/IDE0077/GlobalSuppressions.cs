using System.Diagnostics.CodeAnalysis;

// This suppression intentionally uses a legacy target to trigger the IDE0077 warning.
[assembly: SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:Elements should be documented",
    Justification = "Intentionally uses legacy target",
    Scope = "member",
    Target = "Tdg5.StandardConventions.Tests.Data.IDE0077.ProjectScopedExpectations.#Method")]
