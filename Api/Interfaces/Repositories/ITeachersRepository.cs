using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ITeachersRepository : IRepository<Teacher>
{
}

public class FindManyTeachersParams : TeacherProps;

public class CountTeachersParams : FindManyTeachersParams;

public class ExistsTeachersParams : CountTeachersParams;

public class ExclusiveTeachersParams : ExistsTeachersParams
{
    public int ExcludeId { get; set; }
}

public record OrderByTeachersParams : OrderByParams
{
    public string? YearId { get; set; }
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
    public string? Unit { get; set; }
    public string? CivilStatus { get; set; }
    public string? Position { get; set; }
    public string? Discipline { get; set; }
    public string? Situation { get; set; }
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
}

public record IncludesTeachersParams : IncludesParams
{
    public bool? Unit { get; set; }
    public bool? CivilStatus { get; set; }
    public bool? Position { get; set; }
    public bool? Discipline { get; set; }
    public bool? Situation { get; set; }
}
