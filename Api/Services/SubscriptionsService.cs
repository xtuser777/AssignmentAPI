using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class SubscriptionsService(IUnitOfWork unitOfWork) : ISubscriptionsService
{
    public async Task<Subscription> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .SubscriptionsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Subscription>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.SubscriptionsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.SubscriptionsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Subscription> CreateAsync(CreateServiceParams parameters)
    {
        var props = (SubscriptionProps)parameters.Props;
        var subscription = new Subscription(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SubscriptionsRepository.CreateAsync(subscription);
        await unitOfWork.Commit(transaction);
        return subscription;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (SubscriptionProps)parameters.Props;
        var subscription = await FindOneAsync(parameters);
        subscription.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SubscriptionsRepository.Update(subscription);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var subscription = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SubscriptionsRepository.Delete(subscription);
        await unitOfWork.Commit(transaction);
    }
{
}
