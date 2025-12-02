using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class SituationsView : ISituationsView
{
    public CreateSituationsResponse? Create(Situation? situation)
    {
        if (situation == null)
        {
            return null;
        }

        return new CreateSituationsResponse
        {
            Id = situation.Id,
        };
    }

    public FindOneSituationsResponse? FindOne(Situation? situation)
    {
        if (situation == null)
        {
            return null;
        }

        return new FindOneSituationsResponse
        {
            Id = situation.Id,
            Name = situation.Name,
        };
    }

    public IEnumerable<FindManySituationsResponse> FindMany(IEnumerable<Situation>? situations)
    {
        if (situations == null)
        {
            return [];
        }

        return situations.Select(situation => new FindManySituationsResponse
        {
            Id = situation.Id,
            Name = situation.Name,
        });
    }
}
