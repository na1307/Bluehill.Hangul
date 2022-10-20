#if NETFRAMEWORK && !NET35_OR_GREATER
namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
internal sealed class ExtensionAttribute : Attribute { }
#endif