using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class StringMaxLengthAttribute : MaxLengthAttribute
{
    public StringMaxLengthAttribute(int maxLength) : base(maxLength)
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.MaxLength);
    }
}
