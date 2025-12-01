namespace Assignment.Api.Exceptions;

public class AssignmentException(string message) : SystemException(message)
{
}