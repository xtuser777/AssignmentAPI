using Assignment.Api.Enums;
using Assignment.Api.Extensions;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class UsersRolesView : IUsersRolesView
{
    public IEnumerable<TranslatableField> FindMany()
    {
        var usersRoles = Enum.GetValues<UserRole>();
        return usersRoles.Select(x => new TranslatableField
        {
            Value = x.ToString(),
            DisplayValue = x.GetDisplayValue()
        });
    }
}
