using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class UnitsService(IUnitOfWork unitOfWork) : IUnitsService
{
    public async Task<Unit> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork
            .UnitsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.UnitsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork
            .UnitsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Unit> CreateAsync(CreateServiceParams parameters)
    {
        var props = (UnitProps)parameters.Props;
        var unit = new Unit(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UnitsRepository.CreateAsync(unit);
        await unitOfWork.Commit(transaction);
        return unit;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (UnitProps)parameters.Props;
        var unit = await FindOneAsync(parameters);
        unit.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Update(unit);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var unit = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UnitsRepository.Delete(unit);
        await unitOfWork.Commit(transaction);
    }
{
}
