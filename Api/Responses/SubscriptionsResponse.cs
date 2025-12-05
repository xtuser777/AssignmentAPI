namespace Assignment.Api.Responses;

public record CreateSubscriptionsResponse
{
    public int? SubscriptionId { get; set; }
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
}

public record FindManySubscriptionsResponse
{
    public int? SubscriptionId { get; set; }
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? TeacherUnit { get; set; }
    public int? PreferenceId { get; set; }
    public string? PreferenceName { get; set; }
}

public record FindOneSubscriptionsResponse
{
    public int? SubscriptionId { get; set; }
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public int? PreferenceId { get; set; }
    public FindOneSubscriptionsTeacherResponse? Teacher { get; set; }
    public FindOneSubscriptionsPreferenceResponse? Preference { get; set; }
    public IEnumerable<FindOneSubscriptionsTitlesResponse>? Titles { get; set; }
    public IEnumerable<FindOneSubscriptionsPointsResponse>? Points { get; set; }
}

public record FindOneSubscriptionsTeacherResponse
{
    public int? TeacherId { get; set; }
    public string? Name { get; set; }
}

public record FindOneSubscriptionsPreferenceResponse
{
    public int? PreferenceId { get; set; }
    public string? Name { get; set; }
}

public record FindOneSubscriptionsTitlesResponse
{
    public int? SubscriptionId { get; set; }
    public int? TitleId { get; set; }
    public string? Title { get; set; }
    public decimal? Value { get; set; }
}

public record FindOneSubscriptionsPointsResponse
{
    public int? SubscriptionId { get; set; }
    public int? Order { get; set; }
    public string? Description { get; set; }
    public decimal? Points { get; set; }
}