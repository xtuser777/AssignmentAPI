using Assignment.Api.Attributes;

namespace Assignment.Api.Requests;

public record CreateSubscriptionsRequest
{
    [RequiredField]
    [GuidValue]
    public Guid? YearId { get; set; }

    [RequiredField]
    [GuidValue]
    public Guid? TeacherId { get; set; }

    [RequiredField]
    [GuidValue]
    public Guid? PreferenceId { get; set; }

    [RequiredField]
    public IEnumerable<CreateSubscriptionsTitlesRequest> Titles { get; set; } = [];
 }

public record UpdateSubscriptionsRequest
{
    [GuidValue]
    public Guid? YearId { get; set; }

    [GuidValue]
    public Guid? TeacherId { get; set; }

    [GuidValue]
    public Guid? PreferenceId { get; set; }

    [RequiredField]
    public IEnumerable<CreateSubscriptionsTitlesRequest> Titles { get; set; } = [];
}

public record CreateSubscriptionsTitlesRequest
{
    [RequiredField]
    [GuidValue]
    public Guid? TitleId { get; set; }

    [RequiredField]
    public decimal? Value { get; set; }
}
