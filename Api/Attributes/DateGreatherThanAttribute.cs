using System.ComponentModel.DataAnnotations;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class DateGreatherThanAttribute : ValidationAttribute
{
    private readonly string _dateGreatherThan;

    public DateGreatherThanAttribute(string dateGreatherThan)
    {
        _dateGreatherThan = dateGreatherThan;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.DateGreatherThan);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly dateValue && dateValue != DateOnly.MinValue)
        {
            var comparisonProperty = validationContext.ObjectType.GetProperty(_dateGreatherThan);
            if (comparisonProperty != null) 
            {
                var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance);
                if (comparisonValue is DateOnly comparisonDateValue && comparisonDateValue != DateOnly.MinValue)
                {
                    if (dateValue > comparisonDateValue)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
        }
        return ValidationResult.Success;
    }
}
