using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Resources.Messages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Attributes;

public class ConnectionAttribute<T>(Type repositoryType, Type existsType) : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        if (value is not int code || code == int.MinValue)
        {
            return ValidationResult.Success;
        }
        var repository =
            (IRepository<T>)validationContext
                .GetService(repositoryType)!;
        var props = (Entity)existsType.GetConstructor(Type.EmptyTypes)!
                .Invoke([])!;
        var propertyName = validationContext.MemberName!;
        props.GetType().GetProperty(propertyName)!
                .SetValue(props, code);
        bool exists = repository
            .ExistsAsync(props)
            .GetAwaiter().GetResult();
        if (!exists)
        {
            return new ValidationResult(
                string.Format(
                    Errors.ConnectionNotFound,
                    validationContext.DisplayName, code));
        }

        return ValidationResult.Success;
    }
}
