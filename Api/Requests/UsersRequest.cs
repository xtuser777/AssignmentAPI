using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Requests;

public record CreateUsersRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [StringMinLength(3)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    public string? Username { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [StringMinLength(6)]
    public string? Password { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    public string? Name { get; set; } = string.Empty;

    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    public string? Email { get; set; } = string.Empty;

    [RequiredField]
    public char? Active { get; set; }

    [RequiredField]
    [Connection<Role>(typeof(IRolesRepository), typeof(CountRolesParams))]
    public int? RoleId { get; set; }

    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
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
    public string? Username { get; set; } = string.Empty;

    [StringMaxLength(100)]
    public string? Password { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(1)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    public string? Name { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(5)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    public string? Email { get; set; } = string.Empty;

    public char? Active { get; set; }

    [Connection<Role>(typeof(IRolesRepository), typeof(CountRolesParams))]
    public int? RoleId { get; set; }

    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
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
