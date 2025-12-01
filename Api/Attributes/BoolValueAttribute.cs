using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class BoolValueAttribute : ValidationAttribute
{
    public BoolValueAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.InvalidBoolean);
    }
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        return value is null or bool 
            ? ValidationResult.Success 
            : new ValidationResult(
                FormatErrorMessage(validationContext.DisplayName));
    }
}
