using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class DatePresentPastAttribute : ValidationAttribute
{
    public DatePresentPastAttribute()
    {
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.DatePresentPast);
    }
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success; // Consider null as valid, use [Required] for null checks
        }
        var currentValue = (DateOnly)(value ?? throw new ArgumentNullException(nameof(value)));
        if (currentValue != DateOnly.MinValue && currentValue > DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}
