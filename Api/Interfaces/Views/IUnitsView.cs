using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IUnitsView
{
    CreateUnitsResponse? Create(Unit? unit);
    FindOneUnitsResponse? FindOne(Unit? unit);
    IEnumerable<FindManyUnitsResponse> FindMany(IEnumerable<Unit>? units);
}
