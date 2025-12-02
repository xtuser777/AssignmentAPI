using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IYearsView
{
    CreateYearsResponse? Create(Year? year);
    FindOneYearsResponse? FindOne(Year? year);
    IEnumerable<FindManyYearsResponse> FindMany(IEnumerable<Year>? years);
}
