using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IUsersView
{
    CreateUsersResponse? Create(User? user);
    FindOneUsersResponse? FindOne(User? user);
    IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users);
}
