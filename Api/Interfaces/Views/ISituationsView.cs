using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface ISituationsView
{
    CreateSituationsResponse? Create(Situation? situation);
    FindOneSituationsResponse? FindOne(Situation? situation);
    IEnumerable<FindManySituationsResponse> FindMany(IEnumerable<Situation>? situations);
}
