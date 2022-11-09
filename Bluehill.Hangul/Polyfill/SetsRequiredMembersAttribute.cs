#if !NET7_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
[ExcludeFromCodeCoverage]
internal sealed class SetsRequiredMembersAttribute : Attribute { }
#endif