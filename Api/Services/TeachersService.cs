using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class TeachersService(IUnitOfWork unitOfWork) : ITeatchersService
{
    public async Task<Teatcher> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .TeatchersRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Teatcher>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.TeatchersRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TeatchersRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Teatcher> CreateAsync(CreateServiceParams parameters)
    {
        var props = (TeatcherProps)parameters.Props;
        var teacher = new Teatcher(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TeatchersRepository.CreateAsync(teacher);
        await unitOfWork.Commit(transaction);
        return teacher;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (TeatcherProps)parameters.Props;
        var teacher = await FindOneAsync(parameters);
        teacher.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TeatchersRepository.Update(teacher);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var teacher = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TeatchersRepository.Delete(teacher);
        await unitOfWork.Commit(transaction);
    }
{
}
