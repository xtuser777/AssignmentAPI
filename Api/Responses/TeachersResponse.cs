namespace Assignment.Api.Responses;

public record CreateTeachersResponse
{
    public Guid? Id { get; set; }
}

public record FindManyTeachersResponse
{
    public Guid? Id { get; set; }
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
    public Guid? YearId { get; set; }
    public int? Year {  get; set; }
    public Guid? UnitId { get; set; }
    public string? UnitName { get; set; }
    public Guid? CivilStatusId { get; set; }
    public string? CivilStatusName { get; set; }
    public Guid? PositionId { get; set; }
    public string? PositionName { get; set; }
    public Guid? DisciplineId { get; set; }
    public string? DisciplineName { get; set; }
    public Guid? SituationId { get; set; }
    public string? SituationName { get; set; }
    public string? Speciality { get; set; }
    public bool? IsRemove { get; set; }
    public bool? IsAdido { get; set; }
    public bool? IsReadapted { get; set; }
    public bool? IsReadingRoom { get; set; }
    public bool? IsComputing { get; set; }
    public bool? IsSupplementCharge { get; set; }
    public bool? IsTutoring { get; set; }
    public bool? IsAmbientalEdication { get; set; }
    public bool? IsRobotics { get; set; }
    public bool? IsMusic { get; set; }
}

public record FindOneTeachersResponse
{
    public Guid? Id { get; set; }
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
    public Guid? YearId { get; set; }
    public Guid? UnitId { get; set; }
    public Guid? CivilStatusId { get; set; }
    public Guid? PositionId { get; set; }
    public Guid? DisciplineId { get; set; }
    public Guid? SituationId { get; set; }
    public string? Speciality { get; set; }
    public bool? IsRemove { get; set; }
    public bool? IsAdido { get; set; }
    public bool? IsReadapted { get; set; }
    public bool? IsReadingRoom { get; set; }
    public bool? IsComputing { get; set; }
    public bool? IsSupplementCharge { get; set; }
    public bool? IsTutoring { get; set; }
    public bool? IsAmbientalEdication { get; set; }
    public bool? IsRobotics { get; set; }
    public bool? IsMusic { get; set; }
}
