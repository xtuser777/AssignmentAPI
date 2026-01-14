using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IClassificationsRepository : IRepository<Classification>
{
}

public class FindManyClassificationsParams : ClassificationProps;

public class CountClassificationsParams : FindManyClassificationsParams;

public class ExistsClassificationsParams : CountClassificationsParams;

public record OrderByClassificationsParams : OrderByParams
{
    public string? YearId { get; set; }
    public string? Subscription { get; set; }
    public string? Name { get; set; }
    public string? Situation { get; set; }
    public string? Position { get; set; }
    public string? Unit { get; set; }
    public string? Discipline { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Speciality { get; set; }
    public string? Remove { get; set; }
    public string? Adido { get; set; }
    public string? Readapted { get; set; }
    public string? ReadingRoom { get; set; }
    public string? Computing { get; set; }
    public string? SupplementCharge { get; set; }
    public string? Tutoring { get; set; }
    public string? AmbientalEdication { get; set; }
    public string? Robotics { get; set; }
    public string? Music { get; set; }
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
    public string? Total { get; set; }
}
