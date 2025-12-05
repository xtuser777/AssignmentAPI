using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class TitlesView : ITitlesView
{
    public CreateTitlesResponse? Create(Title? title)
    {
        if (title == null)
        {
            return null;
        }

        return new CreateTitlesResponse
        {
            YearId = title.YearId,
            TitleId = title.TitleId,
        };
    }

    public FindOneTitlesResponse? FindOne(Title? title)
    {
        if (title == null)
        {
            return null;
        }

        return new FindOneTitlesResponse
        {
            TitleId = title.TitleId,
            Alias = title.Alias,
            Description = title.Description,
            Order = title.Order,
            Max = title.Max,
            Type = title.Type,
            Weight = title.Weight,
            Active = title.Active,
            YearId = title.YearId,
        };
    }

    public IEnumerable<FindManyTitlesResponse> FindMany(IEnumerable<Title>? titles)
    {
        if (titles == null)
        {
            return [];
        }

        return titles.Select(title => new FindManyTitlesResponse
        {
            TitleId = title.TitleId,
            Alias = title.Alias,
            Description = title.Description,
            Order = title.Order,
            Max = title.Max,
            Type = title.Type,
            Weight = title.Weight,
            Active = title.Active,
            YearId = title.YearId,
        });
    }
}
