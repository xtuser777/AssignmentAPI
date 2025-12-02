using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class CivilStatusesView : ICivilStatusesView
{
    public CreateCivilStatusesResponse? Create(CivilStatus? status)
    {
        if (status == null)
        {
            return null;
        }

        return new CreateCivilStatusesResponse
        { 
            Id = status.Id 
        };
    }

    public FindOneCivilStatusesResponse? FindOne(CivilStatus? status)
    {
        if (status == null)
        {
            return null;
        }

        return new FindOneCivilStatusesResponse
        {
            Id = status.Id,
            Name = status.Name,
        };
    }

    public IEnumerable<FindManyCivilStatusesResponse> FindMany(IEnumerable<CivilStatus>? statuses)
    {
        if (statuses == null)
        {
            return [];
        }

        return statuses.Select(status => new FindManyCivilStatusesResponse
        {
            Id = status.Id,
            Name = status.Name,
        });
    }
}
