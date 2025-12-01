namespace Assignment.Api.Exceptions;

public class ConverterException(string propertyName, string message) : AssignmentException(message)
{
    public string PropertyName { get; } = propertyName;
}
