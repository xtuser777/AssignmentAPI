using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IClassificationsRepository : IRepository<Classification>
{
}

public class FindManyClassificationsParams : ClassificationProps;

public class CountClassificationsParams : FindManyClassificationsParams;

public class ExistsClassificationsParams : CountClassificationsParams;

public class ExclusiveClassificationsParams : CountClassificationsParams
{
    public Guid ExcludeId { get; set; }
}

public record OrderByClassificationsParams : OrderByParams
{
    public string? Year { get; set; }
    public string? Subscription { get; set; }
    public string? Name { get; set; }
    public string? Situation { get; set; }
    public string? Position { get; set; }
    public string? Unit { get; set; }
    public string? Discipline { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Speciality { get; set; }
    public string? IsRemove { get; set; }
    public string? IsAdido { get; set; }
    public string? IsReadapted { get; set; }
    public string? IsReadingRoom { get; set; }
    public string? IsComputing { get; set; }
    public string? IsSupplementCharge { get; set; }
    public string? IsTutoring { get; set; }
    public string? IsAmbientalEdication { get; set; }
    public string? IsRobotics { get; set; }
    public string? IsMusic { get; set; }
    public string? T1 { get; set; }
    public string? T2 { get; set; }
    public string? T3 { get; set; }
    public string? T4 { get; set; }
    public string? T5 { get; set; }
    public string? T6 { get; set; }
    public string? T7 { get; set; }
    public string? T8 { get; set; }
    public string? T9 { get; set; }
    public string? T10 { get; set; }
    public string? T11 { get; set; }
    public string? T12 { get; set; }
    public string? T13 { get; set; }
    public string? T14 { get; set; }
    public string? T15 { get; set; }
    public string? T16 { get; set; }
    public string? T17 { get; set; }
    public string? T18 { get; set; }
    public string? T19 { get; set; }
    public string? T20 { get; set; }
    public string? T21 { get; set; }
    public string? T22 { get; set; }
}

public record IncludesClassificationsParams : IncludesParams
{
    public bool? Year { get; set; }
}
