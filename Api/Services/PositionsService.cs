using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class PositionsService(IUnitOfWork unitOfWork) : IPositionsService
{
    public async Task<Position> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .PositionsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Position>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.PositionsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.PositionsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Position> CreateAsync(CreateServiceParams parameters)
    {
        var props = (PositionProps)parameters.Props;
        var position = new Position(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PositionsRepository.CreateAsync(position);
        await unitOfWork.Commit(transaction);
        return position;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (PositionProps)parameters.Props;
        var position = await FindOneAsync(parameters);
        position.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Update(position);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var position = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PositionsRepository.Delete(position);
        await unitOfWork.Commit(transaction);
    }
}
