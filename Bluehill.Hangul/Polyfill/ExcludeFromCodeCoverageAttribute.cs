#if !NET5_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
[ExcludeFromCodeCoverage]
internal sealed class ExcludeFromCodeCoverageAttribute : Attribute {
    public string? Justification { get; set; }
}
#endif