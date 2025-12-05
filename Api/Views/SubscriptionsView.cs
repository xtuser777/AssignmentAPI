using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class SubscriptionsView : ISubscriptionsView
{
    public CreateSubscriptionsResponse? Create(Subscription? subscription)
    {
        if (subscription == null)
        {
            return null;
        }

        return new CreateSubscriptionsResponse
        {
            SubscriptionId = subscription.SubscriptionId,
        };
    }

    public FindOneSubscriptionsResponse? FindOne(Subscription? subscription)
    {
        if (subscription == null)
        {
            return null;
        }

        return new FindOneSubscriptionsResponse
        {
            SubscriptionId = subscription.SubscriptionId,
            YearId = subscription.YearId,
            TeacherId = subscription.TeacherId,
            PreferenceId = subscription.PreferenceId,
            Teacher = subscription.Teacher != null 
                ? new FindOneSubscriptionsTeacherResponse 
                {
                    TeacherId = subscription.Teacher.TeacherId,
                    Name = subscription.Teacher.Name,
                } 
                : null,
            Preference = subscription.Preference != null 
                ? new FindOneSubscriptionsPreferenceResponse 
                {
                    PreferenceId = subscription.Preference.PreferenceId,
                    Name = subscription.Preference.Name,
                } 
                : null,
            Titles = subscription.Titles?.Select(title => 
                        new FindOneSubscriptionsTitlesResponse 
                        { 
                            SubscriptionId = title.SubscriptionId,
                            Value = title.Value,
                            TitleId = title.TitleId,
                            Title = title.Title?.Description,
                        }),
            Points = subscription.Points?.Select(points => 
                        new FindOneSubscriptionsPointsResponse
                        {
                            SubscriptionId = points.SubscriptionId,
                            Description = points.Description,
                            Order = points.Order,
                            Points = points.Points
                        }),

        };
    }

    public IEnumerable<FindManySubscriptionsResponse> FindMany(IEnumerable<Subscription>? subscriptions)
    {
        if (subscriptions == null)
        {
            return [];
        }

        return subscriptions.Select(subscription => new FindManySubscriptionsResponse
        {
            SubscriptionId = subscription.SubscriptionId,
            YearId = subscription.YearId,
            TeacherId = subscription.TeacherId,
            TeacherName = subscription.Teacher?.Name,
            TeacherUnit = subscription.Teacher?.Unit?.Name,
            PreferenceId = subscription.PreferenceId,
            PreferenceName = subscription.Preference?.Name,
        });
    }
}
