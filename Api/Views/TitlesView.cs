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
            Id = title.Id,
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
            Id = title.Id,
            Alias = title.Alias,
            Description = title.Description,
            Order = title.Order,
            Max = title.Max,
            Type = title.Type,
            Weight = title.Weight,
            IsActive = title.IsActive,
            YearId = title.YearId,
            Year = title.Year != null 
                ? new FindOneTitlesYearResponse 
                {
                    Id = title.Year.Id,
                    Value = title.Year.Value,
                } : null,
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
            Id = title.Id,
            Alias = title.Alias,
            Description = title.Description,
            Order = title.Order,
            Max = title.Max,
            Type = title.Type,
            Weight = title.Weight,
            IsActive = title.IsActive,
            YearId = title.YearId,
        });
    }
}
