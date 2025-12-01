using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Resources.Messages;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Attributes;

public class ConnectionAttribute<T>(Type repositoryType) : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not Guid id || id == Guid.Empty)
        {
            return ValidationResult.Success;
        }
        var repository =
            (IRepository<T>)validationContext
                .GetService(repositoryType)!;
        bool exists = repository
            .ExistsAsync(new Entities.Entity { Id = id })
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound,
                    validationContext.DisplayName, id));
        }

        return ValidationResult.Success;
    }
}
