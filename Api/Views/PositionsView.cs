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
            PositionId = position.PositionId,
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
            PositionId = position.PositionId,
            Name = position.Name,
            Active = position.Active,
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
            PositionId = position.PositionId,
            Name = position.Name,
            Active = position.Active,
        });
    }
}
