using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class PointsBySubscriptionsService(IUnitOfWork unitOfWork) : IPointsBySubscriptionsService
{
    public async Task<PointsBySubscription> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .PointsBySubscriptionsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<PointsBySubscription>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.PointsBySubscriptionsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.PointsBySubscriptionsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<PointsBySubscription> CreateAsync(CreateServiceParams parameters)
    {
        var props = (PointsBySubscriptionProps)parameters.Props;
        var points = new PointsBySubscription(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PointsBySubscriptionsRepository.CreateAsync(points);
        await unitOfWork.Commit(transaction);
        return points;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (PointsBySubscriptionProps)parameters.Props;
        var points = await FindOneAsync(parameters);
        points.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PointsBySubscriptionsRepository.Update(points);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var points = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PointsBySubscriptionsRepository.Delete(points);
        await unitOfWork.Commit(transaction);
    }
{
}
