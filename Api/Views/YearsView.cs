using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class YearsView : IYearsView
{
    public CreateYearsResponse? Create(Year? year)
    {
        if (year == null)
        {
            return null;
        }

        return new CreateYearsResponse
        {
            YearId = year.YearId,
        };
    }

    public FindOneYearsResponse? FindOne(Year? year)
    {
        if (year == null)
        {
            return null;
        }

        return new FindOneYearsResponse
        {
            YearId = year.YearId,
            Record = year.Record,
            Resolution = year.Resolution,
            IsBlocked = year.IsBlocked
        };
    }

    public IEnumerable<FindManyYearsResponse> FindMany(IEnumerable<Year>? years)
    {
        if (years == null)
        {
            return [];
        }

        return years.Select(year => new FindManyYearsResponse
        {
            YearId = year.YearId,
            Record = year.Record,
            Resolution = year.Resolution,
            IsBlocked = year.IsBlocked
        });
    }
}
