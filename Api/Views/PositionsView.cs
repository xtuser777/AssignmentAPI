using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class PositionsView : IPositionsView
{
    public CreatePositionsResponse? Create(Position? position)
    {
        if (position == null)
        {
            return null;
        }

        return new CreatePositionsResponse
        {
            Id = position.Id,
        };
    }

    public FindOnePositionsResponse? FindOne(Position? position)
    {
        if (position == null)
        {
            return null;
        }

        return new FindOnePositionsResponse
        {
            Id = position.Id,
            Name = position.Name,
            IsActive = position.IsActive,
        };
    }

    public IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions)
    {
        if (positions == null)
        {
            return [];
        }

        return positions.Select(position => new FindManyPositionsResponse
        {
            Id = position.Id,
            Name = position.Name,
            IsActive = position.IsActive,
        });
    }
}
