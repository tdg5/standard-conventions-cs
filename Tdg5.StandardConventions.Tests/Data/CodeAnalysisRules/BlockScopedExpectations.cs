using System;
using System.Collections.Generic;
using Tdg5.StandardConventions.TestAnnotations;

namespace Tdg5.StandardConventions.Tests.Data.CodeAnalysisRules;

/// <summary>
/// Various block scoped expectations for CodeAnalysis rules.
/// </summary>
public class BlockScopedExpectations
{
    /// <summary>
    /// A method that could benefit from using <see
    /// cref="ArgumentException.ThrowIfNullOrEmpty"/>.
    /// </summary>
    /// <param name="arg">A string argument.</param>
    [CodeAnalysisViolationExpected("CA1511", "Warning")]
    [IncidentalCodeAnalysisViolationExpected("SA1122")]
    public static void CA1511_UseArgumentExceptionThrowHelper(string arg)
    {
        if (string.IsNullOrEmpty(arg))
        {
            // The first arg below must be empty string or the violation won't fire.
            throw new ArgumentException("", nameof(arg));
        }
    }

    /// <summary>
    /// A method that could benefit from using one of the
    /// ArgumentOutOfRangeException.Throw* methods.
    /// </summary>
    /// <param name="arg">An integer argument.</param>
    [CodeAnalysisViolationExpected("CA1512", "Warning")]
    public static void CA1512_UseArgumentOutOfRangeExceptionThrowHelper(int arg)
    {
        if (arg < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arg));
        }
    }

    /// <summary>
    /// A class that declares a static method on a generic type.
    /// </summary>
    /// <typeparam name="T">A generic type parameter.</typeparam>
    [CodeAnalysisViolationExpected(
        "CA1000",
        "Info",
        disabledReason: "CA1000 has a severity of silent.")]
    public class CA1000<T>
    {
        /// <summary>
        /// A static method that does nothing.
        /// </summary>
        public static void Method()
        {
        }
    }

    /// <summary>
    /// A class that owns a disposable object but is not disposable itself.
    /// </summary>
    [CodeAnalysisViolationExpected("CA1001", "Info")]
    public class CA1001
    {
        private readonly NoopDisposable disposable;

        /// <summary>
        /// Initializes a new instance of the <see cref="CA1001"/> class.
        /// </summary>
        public CA1001()
        {
            disposable = new NoopDisposable();
            NoopHelper.Noop(disposable);
        }

        private class NoopDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }

    /// <summary>
    /// A class that declares a member that returns a List{T}.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "CA1002", "Info", disabledReason: "CA1002 has a severity of silent.")]
    public class CA1002
    {
        /// <summary>
        /// A static method that does nothing.
        /// </summary>
        /// <returns>A List{T}.</returns>
        public static List<int> Method()
        {
            return [];
        }
    }

    /// <summary>
    /// An attribute class that is not marked with the AttributeUsage attribute.
    /// </summary>
    [CodeAnalysisViolationExpected("CA1018", "Warning")]
    public class CA1018 : Attribute
    {
    }

    /// <summary>
    /// A class that implements IComparable but does not override Object.Equals.
    /// </summary>
    [CodeAnalysisViolationExpected("CA1036", "Warning")]
    public class CA1036 : IComparable
    {
        /// <inheritdoc/>
        public int CompareTo(object? obj) => 0;
    }

    /// <summary>
    /// A sealed class that contains a protected member.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "CA1047", "Warning", disabledReason: "In C# this is handled by SS0628")]
    [IncidentalCodeAnalysisViolationExpected("CS0628")]
    public sealed class CA1047
    {
        private readonly int value = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="CA1047"/> class.
        /// </summary>
        public CA1047()
        {
            Method();
        }

        /// <summary>
        /// A protected method that does nothing.
        /// </summary>
        protected void Method() => NoopHelper.Noop(value);
    }

    /// <summary>
    /// A class that contains a public field.
    /// </summary>
    [CodeAnalysisViolationExpected(
        "CA1051", "Warning", disabledReason: "SA1401 is enabled instead.")]
    [IncidentalCodeAnalysisViolationExpected("SA1401")]
    public sealed class CA1051
    {
        /// <summary>
        /// A public field.
        /// </summary>
        public int Value = 0;
    }

    /// <summary>
    /// A class that contains a method that could benefit from using
    /// ObjectDisposedException.ThrowIf.
    /// </summary>
    public class CA1513_UseObjectDisposedExceptionThrowHelper
    {
        private readonly bool disposed = false;

        /// <summary>
        /// A method that checks if disposed.
        /// </summary>
        [CodeAnalysisViolationExpected("CA1513", "Warning")]
        public void Method()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
