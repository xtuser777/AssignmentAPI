using System.Reflection;

namespace Assignment.Api.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class DisplayValueAttribute(Type resourceType, string resourceName) : Attribute
{
    public string DisplayValue { get; } = (string)(resourceType.GetProperty(
            resourceName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly)
        ?.GetValue(null, null) ?? "");
}