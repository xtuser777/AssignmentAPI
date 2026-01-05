using Assignment.Api.Attributes;
using Assignment.Api.Entities;

namespace Assignment.Api.Requests;

public record CreateSubscriptionsRequest
{
    [RequiredField] public int? YearId { get; set; }

    [RequiredField] public int? TeacherId { get; set; }

    [RequiredField] public int? PreferenceId { get; set; }

    [RequiredField] public IEnumerable<CreateSubscriptionsTitlesRequest> Titles { get; set; } = [];

    [RequiredField] public IEnumerable<CreateSubscriptionsPointsRequest> Points { get; set; } = [];

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
            Titles = request.Titles.Select(t => new TitleBySubscription
            {
                SubscriptionId = 0,
                TeacherId = request.TeacherId,
                TitleId = t.TitleId,
                YearId = request.YearId,
                Value = t.Value
            }).ToList(),
            Points = request.Points.Select(p => new PointsBySubscription
            {
                SubscriptionId = 0,
                Description = p.Description,
                Order = p.Order,
                YearId = request.YearId,
                Points = p.Points,
            }).ToList()
        };
}

public record CreateSubscriptionsTitlesRequest
{
    [RequiredField] public int? TitleId { get; set; }

    [RequiredField] public decimal? Value { get; set; }
}

public record CreateSubscriptionsPointsRequest
{
    [RequiredField] public string? Description { get; set; }
    [RequiredField] public int? Order { get; set; }
    [RequiredField] public decimal? Points { get; set; }
}