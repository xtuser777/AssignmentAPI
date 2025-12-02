using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IClassificationsView
{
    FindOneClassificationsResponse? FindOne(Classification? classification);
    IEnumerable<FindManyClassificationsResponse> FindMany(IEnumerable<Classification>? classifications);
}
