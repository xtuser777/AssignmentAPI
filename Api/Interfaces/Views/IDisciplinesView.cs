using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IDisciplinesView
{
    CreateDisciplinesResponse? Create(Discipline? discipline);
    FindOneDisciplinesResponse? FindOne(Discipline? discipline);
    IEnumerable<FindManyDisciplinesResponse> FindMany(IEnumerable<Discipline>? disciplines);
}
