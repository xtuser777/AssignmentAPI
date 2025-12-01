using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class YearsService(IUnitOfWork unitOfWork) : IYearsService
{
    public async Task<Year> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .YearsRepository
            .FindOneAsync(parameters) 
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Year>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.YearsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.YearsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Year> CreateAsync(CreateServiceParams parameters)
    {
        var props = (YearProps)parameters.Props;
        var year = new Year(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.YearsRepository.CreateAsync(year);
        await unitOfWork.Commit(transaction);
        return year;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (YearProps)parameters.Props;
        var year = await FindOneAsync(parameters);
        year.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.YearsRepository.Update(year);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var year = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.YearsRepository.Delete(year);
        await unitOfWork.Commit(transaction);
    }
}
