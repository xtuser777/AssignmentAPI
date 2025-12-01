using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class TimeGreaterThanCurrentAttribute : ValidationAttribute
{
    private readonly string date;

    public TimeGreaterThanCurrentAttribute(string date)
    {
        this.date = date;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.TimeGreatherThanCurrent);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var property = validationContext.ObjectType.GetProperty(date) 
            ?? throw new ArgumentException(string.Empty);
        var comparisonValue = (DateOnly?)property.GetValue(validationContext.ObjectInstance);
        var currentValue = (TimeOnly)(value ?? throw new ArgumentNullException(nameof(value)));
        if (currentValue == TimeOnly.MinValue)
        {
            return ValidationResult.Success;
        }
        if (
            currentValue < TimeOnly.FromDateTime(DateTime.Now) 
            && comparisonValue == DateOnly.FromDateTime(DateTime.Now))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }
}
