using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IPreferencesView
{
    CreatePreferencesResponse? Create(Preference? preference);
    FindOnePreferencesResponse? FindOne(Preference? preference);
    IEnumerable<FindManyPreferencesResponse> FindMany(IEnumerable<Preference>? preferences);
}
