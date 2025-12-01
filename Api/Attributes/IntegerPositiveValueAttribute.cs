using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class IntegerPositiveValueAttribute : ValidationAttribute
{
    public IntegerPositiveValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.PositiveValue);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) 
        {
            return ValidationResult.Success;
        }
        if (value is int intValue && intValue >= 0)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
