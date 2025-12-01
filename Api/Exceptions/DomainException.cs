namespace Assignment.Api.Exceptions;

public class DomainException(IEnumerable<string> messages) : AssignmentException(string.Join(", ", messages))
{
    public int Code { get; set; } = 400;
}