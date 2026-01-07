using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IRolesView
{
    FindOneRolesResponse? FindOne(Role? role);
    IEnumerable<FindManyRolesResponse> FindMany(IEnumerable<Role>? roles);
}
