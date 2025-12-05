using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("professor")]
[PrimaryKey(nameof(YearId), nameof(TeacherId))]
public class Teacher : TeacherProps
{
    public Teacher() 
    {
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
    [Column("idano")]
    public int? YearId { get; set; }
    
    [Column("idprofessor")]
    public int? TeacherId { get; set; }
    
    [Column("nome")]
    public string? Name { get; set; }
    
    [Column("rg")]
    public string? Identity { get; set; }
    
    [Column("cpf")]
    public string? Document { get; set; }
    
    [Column("filhosdependentes")]
    public int? Dependents { get; set; }
    
    [Column("nascimento")]
    public DateOnly? BirthAt { get; set; }
    
    [Column("endereco")]
    public string? Address {  get; set; }
    
    [Column("bairro")]
    public string? Neighborhood { get; set; }
    
    [Column("cidade")]
    public string? City { get; set; }
    
    [Column("cep")]
    public string? PostalCode { get; set; }
    
    [Column("telefone")]
    public string? Phone { get; set; }
    
    [Column("celular")]
    public string? Cellphone { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("observacoes")]
    public string? Observations { get; set; }
    
    [Column("idunidade")]
    public int? UnitId { get; set; }
    
    [Column("idestado_civil")]
    public int? CivilStatusId { get; set; }
    
    [Column("idcargo")]
    public int? PositionId { get; set; }
    
    [Column("iddisciplina")]
    public int? DisciplineId { get; set; }
    
    [Column("idsituacao")]
    public int? SituationId { get; set; }
    
    [Column("especialidade")]
    public string? Speciality { get; set; }
    
    [Column("remocao")]
    public char? Remove { get; set; }
    
    [Column("adido")]
    public char? Adido { get; set; }
    
    [Column("readaptado")]
    public char? Readapted { get; set; }
    
    [Column("saladeleitura")]
    public char? ReadingRoom { get; set; }
    
    [Column("informatica")]
    public char? Computing { get; set; }
    
    [Column("cargasuplementar")]
    public char? SupplementCharge { get; set; }
    
    [Column("reforco")]
    public char? Tutoring { get; set; }
    
    [Column("educacaoambiental")]
    public char? AmbientalEdication { get; set; }
    
    [Column("robotica")]
    public char? Robotics { get; set; }
    
    [Column("musica")]
    public char? Music { get; set; }

    [ForeignKey(nameof(YearId))]
    public virtual Year? Year { get; set; }

    [ForeignKey(nameof(UnitId))]
    public virtual Unit? Unit { get; init; }

    [ForeignKey(nameof(CivilStatusId))]
    public virtual CivilStatus? CivilStatus { get; init; }

    [ForeignKey(nameof(PositionId))]
    public virtual Position? Position { get; init; }

    [ForeignKey(nameof(DisciplineId))]
    public virtual Discipline? Discipline { get; init; }

    [ForeignKey(nameof(SituationId))]
    public virtual Situation? Situation { get; init; }
}
