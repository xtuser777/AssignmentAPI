using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IPositionsView
{
    CreatePositionsResponse? Create(Position? position);
    FindOnePositionsResponse? FindOne(Position? position);
    IEnumerable<FindManyPositionsResponse> FindMany(IEnumerable<Position>? positions);
}
