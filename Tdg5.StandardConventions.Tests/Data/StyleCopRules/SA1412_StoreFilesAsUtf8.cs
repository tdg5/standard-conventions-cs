﻿using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.StyleCopRules;

/// <summary>
/// A file that is not stored as UTF-8.
/// </summary>
[FileAnalysisViolationExpected(
    "SA1412", "Warning", disabledReason: "SA1412 is disabled.")]
public class SA1412_StoreFilesAsUtf8
{
}
