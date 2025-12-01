using Assignment.Api.Attributes;
using Assignment.Api.Resources.DisplayValues;

namespace Assignment.Api.Enums;

public enum UserRole
{
    [DisplayValue(typeof(UsersUnits), "Admin")]
    Admin = 0,
    [DisplayValue(typeof(UsersUnits), "Superuser")]
    Superuser = 1,
    [DisplayValue(typeof(UsersUnits), "User")]
    User = 2,
}
