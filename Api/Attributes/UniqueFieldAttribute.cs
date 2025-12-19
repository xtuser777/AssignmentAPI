using System.ComponentModel.DataAnnotations;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Attributes;

public class UniqueFieldAttribute<TEntity> : ValidationAttribute
{
    private readonly Type _repositoryType;
    private readonly Type _paramsType;

    public UniqueFieldAttribute(Type repositoryType, Type paramsType)
    {
        _repositoryType = repositoryType;
        _paramsType = paramsType;
        ErrorMessageResourceType = typeof(Errors);
        ErrorMessageResourceName = nameof(Errors.UniqueField);
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is null || (string)value == "")
        {
            return ValidationResult.Success;
        }
        var repository = (IRepository<TEntity>)context.GetService(_repositoryType)!;
        var httpContextAccessor = 
            (IHttpContextAccessor)context.GetService(typeof(IHttpContextAccessor))!;
        var httpContext = httpContextAccessor.HttpContext!;
        var method = httpContext.Request.Method;
        var propertyName = context.MemberName!;
        if (method == HttpMethods.Post)
        {
            var existsParams = 
                (Entity)_paramsType.GetConstructor(Type.EmptyTypes)!
                .Invoke([])!;
            existsParams.GetType().GetProperty(propertyName)!
                .SetValue(existsParams, value.ToString()!);
            var existsTask = repository.ExistsAsync(existsParams);
            existsTask.Wait();
            if (existsTask.Result)
            {
                return new ValidationResult(
                    FormatErrorMessage(context.DisplayName));
            }
        }
        else if (method == HttpMethods.Put || method == HttpMethods.Patch)
        {
            var entityName = context.ObjectType.Name.Replace("Update", "").Replace("sRequest", "");
            var idString = httpContext.GetRouteData().Values[$"{entityName.ToLower()}Id"]?.ToString() ?? "";
            if (int.TryParse(idString, out var id))
            {
                var exclusiveParams =
                    (Entity)_paramsType.GetConstructor(Type.EmptyTypes)!
                    .Invoke([])!;
                exclusiveParams.GetType().GetProperty($"Exclude{entityName}Id")!
                    .SetValue(exclusiveParams, id);
                exclusiveParams.GetType().GetProperty(propertyName)!
                    .SetValue(exclusiveParams, value.ToString()!);
                var exclusive = repository.ExclusiveAsync(exclusiveParams)
                    .GetAwaiter().GetResult();
                if (exclusive)
                {
                    return new ValidationResult(
                        FormatErrorMessage(context.DisplayName));
                }
            }
        }
        return ValidationResult.Success;
    }
}
