using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class DisciplinesService(IUnitOfWork unitOfWork) : IDisciplinesService
{
    public async Task<Discipline> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .DisciplinesRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Discipline>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.DisciplinesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.DisciplinesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Discipline> CreateAsync(CreateServiceParams parameters)
    {
        var props = (DisciplineProps)parameters.Props;
        var discipline = new Discipline(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DisciplinesRepository.CreateAsync(discipline);
        await unitOfWork.Commit(transaction);
        return discipline;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (DisciplineProps)parameters.Props;
        var discipline = await FindOneAsync(parameters);
        discipline.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DisciplinesRepository.Update(discipline);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var discipline = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DisciplinesRepository.Delete(discipline);
        await unitOfWork.Commit(transaction);
    }
}
