using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Teachers")]
public class Teacher : TeacherProps
{
    public Teacher() 
    {
        Id = Guid.NewGuid();
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
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }

    [Required]
    [StringLength(12)]
    public string? Identity { get; set; }

    [Required]
    [StringLength(11)]
    public string? Document { get; set; }

    [Required]
    public int? Dependents { get; set; }

    [Required]
    public DateOnly? BirthAt { get; set; }

    [Required]
    [StringLength(100)]
    public string? Address {  get; set; }

    [Required]
    [StringLength(50)]
    public string? Neighborhood { get; set; }

    [Required]
    [StringLength(50)]
    public string? City { get; set; }

    [Required]
    [StringLength(8)]
    public string? PostalCode { get; set; }

    [Required]
    [StringLength(10)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(11)]
    public string? Cellphone { get; set; }

    [Required]
    [StringLength(11)]
    public string? Email { get; set; }

    [StringLength(255)]
    public string? Observations { get; set; }

    [Required]
    public Guid? YearId { get; set; }

    [Required]
    public Guid? UnitId { get; set; }

    [Required]
    public Guid? CivilStatusId { get; set; }

    [Required]
    public Guid? PositionId { get; set; }

    [Required]
    public Guid? DisciplineId { get; set; }

    [Required]
    public Guid? SituationId { get; set; }

    [StringLength(50)]
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

    [ForeignKey(nameof(YearId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Year? Year { get; init; }

    [ForeignKey(nameof(UnitId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Unit? Unit { get; init; }

    [ForeignKey(nameof(CivilStatusId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public CivilStatus? CivilStatus { get; init; }

    [ForeignKey(nameof(PositionId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Position? Position { get; init; }

    [ForeignKey(nameof(DisciplineId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Discipline? Discipline { get; init; }

    [ForeignKey(nameof(SituationId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Situation? Situation { get; init; }

}
