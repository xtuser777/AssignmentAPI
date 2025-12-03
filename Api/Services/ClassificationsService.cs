using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class ClassificationsService(IUnitOfWork unitOfWork) : IClassificationsService
{
    public async Task<Classification> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .ClassificationsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Classification>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.ClassificationsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.ClassificationsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Classification> CreateAsync(CreateServiceParams parameters)
    {
        var props = (ClassificationProps)parameters.Props;
        var year = new Classification(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ClassificationsRepository.CreateAsync(year);
        await unitOfWork.Commit(transaction);
        return year;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (ClassificationProps)parameters.Props;
        var year = await FindOneAsync(parameters);
        year.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.ClassificationsRepository.Update(year);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var year = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.ClassificationsRepository.Delete(year);
        await unitOfWork.Commit(transaction);
    }
}
