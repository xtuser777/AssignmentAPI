using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class SubscriptionsService(IUnitOfWork unitOfWork) : ISubscriptionsService
{
    public async Task<Subscription> FindOneAsync(FindOneServiceParams parameters)
    {
        var subscription = await unitOfWork
            .SubscriptionsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.SubscriptionNotFound);
        var points = await unitOfWork.PointsBySubscriptionsRepository.FindManyAsync(new FindManyRepositoryParams
            { Where = new FindManyPointsBySubscriptionsParams { SubscriptionId = subscription.SubscriptionId } });
        subscription.Points = points.ToList();

        return subscription;
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
        var subscription = new Subscription(props)
        {
            SubscriptionId = await unitOfWork.SubscriptionsRepository.GetId(x => x.SubscriptionId)
        };
        var titles = props.Titles?.ToList() ?? [];
        titles.ForEach(t => t.SubscriptionId = subscription.SubscriptionId);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SubscriptionsRepository.CreateAsync(subscription);
        foreach (var title in titles)
        {
            unitOfWork.TitlesBySubscriptionsRepository.Update(title);
        }
        await unitOfWork.Commit(transaction);
        return subscription;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (SubscriptionProps)parameters.Props;
        var subscription = await FindOneAsync(parameters);
        subscription.Update(props);
        var titles = props.Titles?.ToList() ?? [];
        titles.ForEach(t => t.SubscriptionId = subscription.SubscriptionId);
        await using var transaction = unitOfWork.BeginTransaction;
        foreach (var title in titles)
        {
            unitOfWork.TitlesBySubscriptionsRepository.Update(title);
        }
        unitOfWork.SubscriptionsRepository.Update(subscription);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var subscription = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork
            .TitlesBySubscriptionsRepository
            .DeleteManyAsync(
            new FindManyTitleBySubscriptionsParams
            { SubscriptionId = subscription.SubscriptionId });
        unitOfWork.SubscriptionsRepository.Delete(subscription);
        await unitOfWork.Commit(transaction);
    }
}
