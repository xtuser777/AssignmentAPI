namespace Assignment.Api.Responses;

public record CreateTeachersResponse
{
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
}

public record FindManyTeachersResponse
{
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public string? Name { get; set; }
    public string? Identity { get; set; }
    public string? Document { get; set; }
    public int? Dependents { get; set; }
    public DateOnly? BirthAt { get; set; }
    public string? Address { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Observations { get; set; }
    public int? UnitId { get; set; }
    public string? UnitName { get; set; }
    public int? CivilStatusId { get; set; }
    public string? CivilStatusName { get; set; }
    public int? PositionId { get; set; }
    public string? PositionName { get; set; }
    public int? DisciplineId { get; set; }
    public string? DisciplineName { get; set; }
    public int? SituationId { get; set; }
    public string? SituationName { get; set; }
    public string? Speciality { get; set; }
    public char? Remove { get; set; }
    public char? Adido { get; set; }
    public char? Readapted { get; set; }
    public char? ReadingRoom { get; set; }
    public char? Computing { get; set; }
    public char? SupplementCharge { get; set; }
    public char? Tutoring { get; set; }
    public char? AmbientalEdication { get; set; }
    public char? Robotics { get; set; }
    public char? Music { get; set; }
}

public record FindOneTeachersResponse
{
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public string? Name { get; set; }
    public string? Identity { get; set; }
    public string? Document { get; set; }
    public int? Dependents { get; set; }
    public DateOnly? BirthAt { get; set; }
    public string? Address { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Observations { get; set; }
    public int? UnitId { get; set; }
    public int? CivilStatusId { get; set; }
    public int? PositionId { get; set; }
    public int? DisciplineId { get; set; }
    public int? SituationId { get; set; }
    public string? Speciality { get; set; }
    public char? Remove { get; set; }
    public char? Adido { get; set; }
    public char? Readapted { get; set; }
    public char? ReadingRoom { get; set; }
    public char? Computing { get; set; }
    public char? SupplementCharge { get; set; }
    public char? Tutoring { get; set; }
    public char? AmbientalEdication { get; set; }
    public char? Robotics { get; set; }
    public char? Music { get; set; }
}
