using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Teatchers")]
public class Teatcher : TeatcherProps
{
    public Teatcher() 
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Teatcher(TeatcherProps props)
    {
        Assign(props);
    }

    public void Update(TeatcherProps props)
    {
        AssignUpdate(props);
    }
}

public class TeatcherProps : Entity
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
    public string? Observations { get; set; }
    [Required]
    [ForeignKey(nameof(Year))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? YearId { get; set; }
    [Required]
    [ForeignKey(nameof(Unit))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? UnitId { get; set; }
    [Required]
    [ForeignKey(nameof(CivilStatus))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? CivilStatusId { get; set; }
    [Required]
    [ForeignKey(nameof(Position))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? PositionId { get; set; }
    [Required]
    [ForeignKey(nameof(Discipline))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? DisciplineId { get; set; }
    [Required]
    [ForeignKey(nameof(Situation))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
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
    public bool? IsMusic { get; set;}
}
