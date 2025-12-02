using Assignment.Api.Entities;
using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface ISubscriptionsView
{
    CreateSubscriptionsResponse? Create(Subscription? subscription);
    FindOneSubscriptionsResponse? FindOne(Subscription? subscription);
    IEnumerable<FindManySubscriptionsResponse> FindMany(IEnumerable<Subscription>? subscriptions);
}
