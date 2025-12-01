using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class DateValueAttribute : ValidationAttribute
{
    public DateValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.InvalidDate);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }
        if (value is DateOnly date)
        {
            if (date == DateOnly.MinValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
}
