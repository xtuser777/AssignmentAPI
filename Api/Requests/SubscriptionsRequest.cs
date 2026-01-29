using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateSubscriptionsRequest
{
    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? YearId { get; set; }

    [RequiredField]
    [Connection<Year>(typeof(ITeachersRepository), typeof(ExistsTeachersParams))]
    [Display(Name = nameof(TeacherId), ResourceType = typeof(Resources.DisplayValues.Requests))] 
    public int? TeacherId { get; set; }

    [RequiredField]
    [Connection<Year>(typeof(IPreferencesRepository), typeof(ExistsPreferencesParams))]
    [Display(Name = nameof(PreferenceId), ResourceType = typeof(Resources.DisplayValues.Requests))] 
    public int? PreferenceId { get; set; }

    [RequiredField]
    [Display(Name = nameof(Titles), ResourceType = typeof(Resources.DisplayValues.Requests))] 
    public IEnumerable<CreateSubscriptionsTitlesRequest> Titles { get; set; } = [];

    [RequiredField]
    [Display(Name = nameof(Points), ResourceType = typeof(Resources.DisplayValues.Requests))] 
    public IEnumerable<CreateSubscriptionsPointsRequest> Points { get; set; } = [];

    public static implicit operator SubscriptionProps(CreateSubscriptionsRequest request)
        => new()
        {
            YearId = request.YearId,
            TeacherId = request.TeacherId,
            PreferenceId = request.PreferenceId,
            Titles =
            [
                ..
                request.Titles.Select(t => new TitleBySubscription
                {
                    SubscriptionId = 0,
                    TeacherId = request.TeacherId,
                    TitleId = t.TitleId,
                    YearId = request.YearId,
                    Value = t.Value
                })
            ],
            Points =
            [
                ..
                request.Points.Select(p => new PointsBySubscription
                {
                    SubscriptionId = 0,
                    Description = p.Description,
                    Order = p.Order,
                    YearId = request.YearId,
                    Points = p.Points,
                })
            ]
        };
}

public record UpdateSubscriptionsRequest
{
    public int? YearId { get; set; }

    public int? TeacherId { get; set; }

    public int? PreferenceId { get; set; }

    [RequiredField] public IEnumerable<CreateSubscriptionsTitlesRequest> Titles { get; set; } = [];

    [RequiredField] public IEnumerable<CreateSubscriptionsPointsRequest> Points { get; set; } = [];

    public static implicit operator SubscriptionProps(UpdateSubscriptionsRequest request)
        => new()
        {
            YearId = request.YearId,
            TeacherId = request.TeacherId,
            PreferenceId = request.PreferenceId,
            Titles = [.. request.Titles.Select(t => new TitleBySubscription
            {
                SubscriptionId = 0,
                TeacherId = request.TeacherId,
                TitleId = t.TitleId,
                YearId = request.YearId,
                Value = t.Value
            })],
            Points = [.. request.Points.Select(p => new PointsBySubscription
            {
                SubscriptionId = 0,
                Description = p.Description,
                Order = p.Order,
                YearId = request.YearId,
                Points = p.Points,
            })]
        };
}

public record CreateSubscriptionsTitlesRequest
{
    [RequiredField]
    [Connection<Year>(typeof(ITitlesRepository), typeof(ExistsTitlesParams))]
    [Display(Name = nameof(TitleId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? TitleId { get; set; }

    [RequiredField]
    [Display(Name = nameof(Value), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Value { get; set; }
}

public record CreateSubscriptionsPointsRequest
{
    [RequiredField]
    [Display(Name = nameof(Description), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Description { get; set; }
    [RequiredField]
    [Display(Name = nameof(Order), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? Order { get; set; }
    [RequiredField]
    [Display(Name = nameof(Points), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Points { get; set; }
}