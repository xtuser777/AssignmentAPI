using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface ITeachersView
{
    CreateTeachersResponse? Create(Teacher? teacher);
    FindOneTeachersResponse? FindOne(Teacher? teacher);
    IEnumerable<FindManyTeachersResponse> FindMany(IEnumerable<Teacher>? teachers);
}
