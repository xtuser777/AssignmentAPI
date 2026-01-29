using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateUsersRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [StringMinLength(3)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Username), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [StringMinLength(6)]
    [Display(Name = nameof(Password), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Password { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Email), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Email { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(Active), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Active { get; set; }

    [RequiredField]
    [Connection<Role>(typeof(IRolesRepository), typeof(CountRolesParams))]
    [Display(Name = nameof(RoleId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? RoleId { get; set; }

    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
    [Display(Name = nameof(UnitId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? UnitId { get; set; }

    public static implicit operator UserProps(CreateUsersRequest request)
    {
        return new UserProps
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active,
            UsersRoles = [new UserRole { RoleId = request.RoleId, Username = request.Username }],
            UsersUnits = request.UnitId != null ? [new UserUnit { UserLogin = request.Username, UnitId = request.UnitId }] : null,
        };
    }
}

public record UpdateUsersRequest
{
    [StringMaxLength(50)]
    [StringMinLength(3)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Username), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Username { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [Display(Name = nameof(Password), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Password { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(1)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(5)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    [Display(Name = nameof(Email), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Email { get; set; } = string.Empty;

    public char? Active { get; set; }

    [Connection<Role>(typeof(IRolesRepository), typeof(CountRolesParams))]
    [Display(Name = nameof(RoleId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? RoleId { get; set; }

    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
    [Display(Name = nameof(UnitId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? UnitId { get; set; }

    public static implicit operator UserProps(UpdateUsersRequest request)
    {
        return new UserProps
        {
            Username = request.Username,
            Password = request.Password == "" ? null : request.Password,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active,
            UsersRoles = [new UserRole { RoleId = request.RoleId, Username = request.Username }],
            UsersUnits = request.UnitId != null ? [new UserUnit { UserLogin = request.Username, UnitId = request.UnitId }] : null,
        };
    }
}
