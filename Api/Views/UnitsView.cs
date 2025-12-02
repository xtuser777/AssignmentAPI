using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class UnitsView : IUnitsView
{
    public CreateUnitsResponse? Create(Unit? unit)
    {
        if (unit == null)
        {
            return null;
        }

        return new CreateUnitsResponse
        {
            Id = unit.Id,
        };
    }

    public FindOneUnitsResponse? FindOne(Unit? unit)
    {
        if (unit == null)
        {
            return null;
        }

        return new FindOneUnitsResponse
        {
            Id = unit.Id,
            Name = unit.Name,
        };
    }

    public IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units)
    {
        if (units == null)
        {
            return [];
        }

        return units.Select(unit => new FindManyUnitsResponse
        {
            Id = unit.Id,
            Name = unit.Name,
        });
    }
}
