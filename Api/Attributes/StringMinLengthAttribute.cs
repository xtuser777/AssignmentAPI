using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class StringMinLengthAttribute : MinLengthAttribute
{
    public StringMinLengthAttribute(int minLength) : base(minLength)
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MinLength);
    }
}
