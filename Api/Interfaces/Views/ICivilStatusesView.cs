using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface ICivilStatusesView
{
    CreateCivilStatusesResponse? Create(CivilStatus? status);
    FindOneCivilStatusesResponse? FindOne(CivilStatus? status);
    IEnumerable<FindManyCivilStatusesResponse> FindMany(IEnumerable<CivilStatus>? statuses);
}
