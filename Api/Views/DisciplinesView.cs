using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class DisciplinesView : IDisciplinesView
{
    public CreateDisciplinesResponse? Create(Discipline? discipline)
    {
        if (discipline == null)
        {
            return null;
        }

        return new CreateDisciplinesResponse
        {
            DisciplineId = discipline.DisciplineId,
        };
    }

    public FindOneDisciplinesResponse? FindOne(Discipline? discipline)
    {
        if (discipline == null)
        {
            return null;
        }

        return new FindOneDisciplinesResponse
        {
            DisciplineId = discipline.DisciplineId,
            Name = discipline.Name,
        };
    }

    public IEnumerable<FindManyDisciplinesResponse> FindMany(IEnumerable<Discipline>? disciplines)
    {
        if (disciplines == null)
        {
            return [];
        }

        return disciplines.Select(discipline => new FindManyDisciplinesResponse
        {
            DisciplineId = discipline.DisciplineId,
            Name = discipline.Name,
        });
    }
}
