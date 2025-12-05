using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Enums;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Requests;

public record CreateUsersUnitsRequest
{
    [RequiredField]
    [Connection<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
    public int UnitId { get; set; }
}

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
    [EnumValue(typeof(UserRole))]
    public string? Role { get; set; }

    [RequiredField]
    public IEnumerable<CreateUsersUnitsRequest> Units { get; set; } = [];

    public static implicit operator UserProps(CreateUsersRequest request)
    {
        return new UserProps
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active,
            Role = Assignment.Api.Utils.Parser.ToEnumOptional<UserRole>(request.Role),
            UsersUnits = [.. request.Units.Select(
                unit => new UserUnit(
                    new UserUnitProps () { UserLogin = request.Username, UnitId = unit.UnitId }))],
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
    [StringMinLength(6)]
    public string? Password { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(1)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    public string? Name { get; set; } = string.Empty;

    [StringMaxLength(100)]
    [StringMinLength(5)]
    [UniqueField<User>(typeof(IUsersRepository), typeof(ExclusiveUsersParams))]
    public string? Email { get; set; } = string.Empty;

    [BoolValue]
    public char? Active { get; set; }

    [EnumValue(typeof(UserRole))]
    public string? Role { get; set; }

    [RequiredField]
    public IEnumerable<CreateUsersUnitsRequest> Units { get; set; } = [];

    public static implicit operator UserProps(UpdateUsersRequest request)
    {
        return new UserProps
        {
            Username = request.Username,
            Password = request.Password,
            Name = request.Name,
            Email = request.Email,
            Active = request.Active,
            Role = Assignment.Api.Utils.Parser.ToEnumOptional<UserRole>(request.Role),
            UsersUnits = [.. request.Units.Select(
                unit => new UserUnit(
                    new UserUnitProps () { UserLogin = request.Username, UnitId = unit.UnitId }))],
        };
    }
}
