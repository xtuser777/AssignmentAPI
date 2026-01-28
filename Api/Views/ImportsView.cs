using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class ImportsView : IImportsView
{
    public CreateImportsResponse? Create(Import? import)
    {
        if (import is null)
            return null;

        return new CreateImportsResponse
        {
            ImportId = import.ImportId,
            YearId = import.YearId
        };
    }

    public IEnumerable<FindManyImportsResponse> FindMany(IEnumerable<Import>? imports)
    {
        if (imports is null)
            return [];

        return imports.Select(import => new FindManyImportsResponse
        {
            ImportId = import.ImportId,
            YearId = import.YearId,
            Date = import.Date,
            Time = import.Time,
            Type = import.Type,
            Login = import.Login
        });
    }

    public FindOneImportsResponse? FindOne(Import? import)
    {
        if (import is null)
            return null;

        return new FindOneImportsResponse
        {
            ImportId = import.ImportId,
            YearId = import.YearId,
            Date = import.Date,
            Time = import.Time,
            Type = import.Type,
            Login = import.Login
        };
    }
}
