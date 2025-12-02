using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class PreferencesView : IPreferencesView
{
    public CreatePreferencesResponse? Create(Preference? preference)
    {
        if (preference == null)
        {
            return null;
        }

        return new CreatePreferencesResponse
        {
            Id = preference.Id,
        };
    }

    public FindOnePreferencesResponse? FindOne(Preference? preference)
    {
        if (preference == null)
        {
            return null;
        }

        return new FindOnePreferencesResponse
        {
            Id = preference.Id,
            Name = preference.Name,
        };
    }

    public IEnumerable<FindManyPreferencesResponse> FindMany(IEnumerable<Preference>? preferences)
    {
        if (preferences == null)
        {
            return [];
        }

        return preferences.Select(preference => new FindManyPreferencesResponse
        {
            Id = preference.Id,
            Name = preference.Name,
        });
    }
}
