using Assignment.Api.Attributes;
using Assignment.Api.Resources.DisplayValues;

namespace Assignment.Api.Enums;

public enum UserRole
{
    [DisplayValue(typeof(UsersRoles), nameof(UsersRoles.Admin))]
    Admin = 0,
    [DisplayValue(typeof(UsersRoles), nameof(UsersRoles.Superuser))]
    Superuser = 1,
    [DisplayValue(typeof(UsersRoles), nameof(UsersRoles.User))]
    User = 2,
}
