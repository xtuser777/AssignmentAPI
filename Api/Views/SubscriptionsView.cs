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
            Id = subscription.Id,
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
            Id = subscription.Id,
            YearId = subscription.YearId,
            TeacherId = subscription.TeacherId,
            PreferenceId = subscription.PreferenceId,
            Teacher = subscription.Teacher != null 
                ? new FindOneSubscriptionsTeacherResponse 
                {
                    Id = subscription.Teacher.Id,
                    Name = subscription.Teacher.Name,
                } 
                : null,
            Preference = subscription.Preference != null 
                ? new FindOneSubscriptionsPreferenceResponse 
                {
                    Id = subscription.Preference.Id,
                    Name = subscription.Preference.Name,
                } 
                : null,
            Titles = subscription.Titles?.Select(title => 
                        new FindOneSubscriptionsTitlesResponse 
                        { 
                            Id = title.Id,
                            Value = title.Value,
                            TitleId = title.TitleId,
                            Title = title.Title?.Description,
                        }),
            Points = subscription.Points?.Select(points => 
                        new FindOneSubscriptionsPointsResponse 
                        {
                            Id = points.Id,
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
            Id = subscription.Id,
            YearId = subscription.YearId,
            TeacherId = subscription.TeacherId,
            TeacherName = subscription.Teacher?.Name,
            TeacherUnit = subscription.Teacher?.Unit?.Name,
            PreferenceId = subscription.PreferenceId,
            PreferenceName = subscription.Preference?.Name,
        });
    }
}
