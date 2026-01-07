using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class RolesView : IRolesView
{
    public IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles)
    {
        if (roles == null)
        {
            return [];
        }

        return roles.Select(r => new FindManyRolesResponse
        {
            RoleId = r.RoleId,
            Description = r.Description,
        });
    }

    public FindOneRolesResponse? FindOne(Role? role)
    {
        if (role == null)
        {
            return null;
        }

        return new FindOneRolesResponse
        {
            RoleId = role.RoleId,
            Description = role.Description,
        };
    }
}
