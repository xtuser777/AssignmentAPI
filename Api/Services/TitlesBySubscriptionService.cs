using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class TitlesBySubscriptionService(IUnitOfWork unitOfWork) : ITitlesBySubscriptionsService
{
    public async Task<TitleBySubscription> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .TitlesBySubscriptionsRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<TitleBySubscription>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.TitlesBySubscriptionsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TitlesBySubscriptionsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<TitleBySubscription> CreateAsync(CreateServiceParams parameters)
    {
        var props = (TitleBySubscriptionProps)parameters.Props;
        var title = new TitleBySubscription(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TitlesBySubscriptionsRepository.CreateAsync(title);
        await unitOfWork.Commit(transaction);
        return title;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (TitleBySubscriptionProps)parameters.Props;
        var title = await FindOneAsync(parameters);
        title.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TitlesBySubscriptionsRepository.Update(title);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var title = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TitlesBySubscriptionsRepository.Delete(title);
        await unitOfWork.Commit(transaction);
    }
}
