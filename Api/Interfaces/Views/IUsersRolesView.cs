using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IUsersRolesView
{
    IEnumerable<TranslatableField> FindMany();
}
