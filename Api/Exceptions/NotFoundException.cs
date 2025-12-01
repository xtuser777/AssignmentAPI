namespace Assignment.Api.Exceptions;

public class NotFoundException(string message) : AssignmentException(message)
{
    public int Code { get; } = 404;
}