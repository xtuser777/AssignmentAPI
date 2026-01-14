using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Services;

public interface ITitlesService : IService<Title>
{
    Task ImportAsync(int yearId);
}
