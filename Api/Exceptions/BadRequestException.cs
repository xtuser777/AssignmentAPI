namespace Assignment.Api.Exceptions;

public class BadRequestException(string message) : AssignmentException(message)
{
    public int Code { get; set; } = 400;
}