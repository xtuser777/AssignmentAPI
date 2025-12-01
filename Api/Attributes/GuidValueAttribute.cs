using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class GuidValueAttribute : ValidationAttribute
{
    public GuidValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = "INVALID_GUID";
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }
        if (value is Guid valueGuid)
        {
            if (valueGuid == Guid.Empty)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
