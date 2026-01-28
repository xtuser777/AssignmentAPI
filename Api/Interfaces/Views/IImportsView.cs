using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IImportsView
{
    CreateImportsResponse? Create(Import? import);
    FindOneImportsResponse? FindOne(Import? import);
    IEnumerable<FindManyImportsResponse> FindMany(IEnumerable<Import>? imports);
}
