using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Services;

public interface ITeachersService : IService<Teacher>
{
    Task ImportAsync(int yearId);
}
