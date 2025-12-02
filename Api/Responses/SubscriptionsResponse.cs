namespace Assignment.Api.Responses;

public record CreateSubscriptionsResponse
{
    public Guid? Id { get; set; }
}

public record FindManySubscriptionsResponse
{
    public Guid? Id { get; set; }
    public Guid? YearId { get; set; }
    public int? Year {  get; set; }
    public Guid? TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? TeacherUnit { get; set; }
    public Guid? PreferenceId { get; set; }
    public string? PreferenceName { get; set; }
}

public record FindOneSubscriptionsResponse
{
    public Guid? Id { get; set; }
    public Guid? YearId { get; set; }
    public Guid? TeacherId { get; set; }
    public Guid? PreferenceId { get; set; }
    public FindOneSubscriptionsYearResponse? Year { get; set; }
    public FindOneSubscriptionsTeacherResponse? Teacher { get; set; }
    public FindOneSubscriptionsPreferenceResponse? Preference { get; set; }
    public IEnumerable<FindOneSubscriptionsTitlesResponse>? Titles { get; set; }
    public IEnumerable<FindOneSubscriptionsPointsResponse>? Points { get; set; }
}

public record FindOneSubscriptionsYearResponse
{
    public Guid? Id { get; set; }
    public int? Value { get; set; }
}

public record FindOneSubscriptionsTeacherResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneSubscriptionsPreferenceResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneSubscriptionsTitlesResponse
{
    public Guid? Id { get; set; }
    public Guid? TitleId { get; set; }
    public string? Title { get; set; }
    public decimal? Value { get; set; }
}

public record FindOneSubscriptionsPointsResponse
{
    public Guid? Id { get; set; }
    public int? Order { get; set; }
    public string? Description { get; set; }
    public decimal? Points { get; set; }
}