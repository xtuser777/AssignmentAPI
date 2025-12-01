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
            Id = user.Id,
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
            Id = user.Id,
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive,
            Role = new TranslatableField
            {
                Value = user.Role.ToString() ?? "",
                DisplayValue = user.Role!.GetDisplayValue()
            },
            UsersUnits = user.UsersUnits?
            .Select(unit => new FindOneUsersUsersUnitsResponse
            {
                Id=unit.Id,
                UserId=unit.UserId,
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
            Id = user.Id,
            Username = user.Username,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive,
            Role = new TranslatableField
            {
                Value = user.Role.ToString() ?? "",
                DisplayValue = user.Role!.GetDisplayValue()
            }
        });
    }
}
