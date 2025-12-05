using Assignment.Api.Entities;
using Assignment.Api.Extensions;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class UsersView : IUsersView
{
    public CreateUsersResponse? Create(User? user)
    {
        if (user == null)
        {
            return null;
        }

        return new CreateUsersResponse
        {
            Username = user.Username,
        };
    }

    public FindOneUsersResponse? FindOne(User? user)
    {
        if (user == null)
        {
            return null;
        }

        return new FindOneUsersResponse
        {
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            Active = user.Active,
            Role = new TranslatableField
            {
                Value = user.Role.ToString() ?? "",
                DisplayValue = user.Role!.GetDisplayValue()
            },
            UsersUnits = user.UsersUnits?
            .Select(unit => new FindOneUsersUsersUnitsResponse
            {
                UserLogin=unit.UserLogin,
                UnitId=unit.UnitId,
            }),
        };
    }

    public IEnumerable<FindManyUsersResponse> FindMany(IEnumerable<User>? users)
    {
        if (users == null)
        {
            return [];
        }

        return users.Select(user => new FindManyUsersResponse
        {
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            Active = user.Active,
            Role = new TranslatableField
            {
                Value = user.Role.ToString() ?? "",
                DisplayValue = user.Role!.GetDisplayValue()
            }
        });
    }
}
