using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ITeatchersRepository : IRepository<Teatcher>
{
}

public class FindManyTeatchersParams : TeatcherProps;

public class CountTeatchersParams : FindManyTeatchersParams;

public class ExistsTeatchersParams : CountTeatchersParams;

public class ExclusiveTeatchersParams : ExistsTeatchersParams
{
    public Guid ExcludeId { get; set; }
}

public record OrderByTeatchersParams : OrderByParams
{
    public string? Name { get; set; }
    public string? Identity { get; set; }
    public string? Document { get; set; }
    public string? Dependents { get; set; }
    public string? BirthAt { get; set; }
    public string? Address { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Observations { get; set; }
    public string? Year { get; set; }
    public string? Unit { get; set; }
    public string? CivilStatus { get; set; }
    public string? Position { get; set; }
    public string? Discipline { get; set; }
    public string? Situation { get; set; }
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
}

public record IncludesTeatchersParams : IncludesParams
{
    public bool? Year { get; set; }
    public bool? Unit { get; set; }
    public bool? CivilStatus { get; set; }
    public bool? Position { get; set; }
    public bool? Discipline { get; set; }
    public bool? Situation { get; set; }
}
