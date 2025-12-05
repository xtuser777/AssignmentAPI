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
            CivilStatusId = status.CivilStatusId 
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
            CivilStatusId = status.CivilStatusId,
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
            CivilStatusId = status.CivilStatusId,
            Name = status.Name,
        });
    }
}
