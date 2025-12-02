using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface ITitlesView
{
    CreateTitlesResponse? Create(Title? title);
    FindOneTitlesResponse? FindOne(Title? title);
    IEnumerable<FindManyTitlesResponse> FindMany(IEnumerable<Title>? titles);
}
