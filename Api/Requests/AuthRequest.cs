using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record AuthRequest
{
    [RequiredField]
    [StringMinLength(3)]
    [StringMaxLength(50)]
    [Display(Name = nameof(Username), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMinLength(6)]
    [StringMaxLength(12)]
    [Display(Name = nameof(Password), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string Password { get; set; } = string.Empty;

    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? YearId { get; set; }
}

public record ResetPasswordAuthRequest
{
    [RequiredField]
    [StringMaxLength(12)]
    [StringMinLength(6)]
    public string? Password { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(12)]
    [StringMinLength(6)]
    public string? NewPassword { get; set; } = string.Empty;
}
