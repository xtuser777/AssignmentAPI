namespace Assignment.Api.Entities;

public class Teacher : TeacherProps
{
    public Teacher() 
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Teacher(TeacherProps props)
    {
        Assign(props);
    }

    public void Update(TeacherProps props)
    {
        AssignUpdate(props);
    }
}

public class TeacherProps : Entity
{
    public string? Name { get; set; }
    public string? Identity { get; set; }
    public string? Document { get; set; }
    public int? Dependents { get; set; }
    public DateOnly? BirthAt { get; set; }
    public string? Address {  get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Phone { get; set; }
    public string? Cellphone { get; set; }
    public string? Email { get; set; }
    public string? Observations { get; set; }
    public int? YearId { get; set; }
    public int? UnitId { get; set; }
    public int? CivilStatusId { get; set; }
    public int? PositionId { get; set; }
    public int? DisciplineId { get; set; }
    public int? SituationId { get; set; }
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

    public Year? Year { get; set; }
    public Unit? Unit { get; init; }
    public CivilStatus? CivilStatus { get; init; }
    public Position? Position { get; init; }
    public Discipline? Discipline { get; init; }
    public Situation? Situation { get; init; }
}
