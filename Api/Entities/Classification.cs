using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

public class Classification : ClassificationProps
{
    public Classification() 
    {
    }

    public Classification(ClassificationProps props)
    {
        Assign(props);
    }
}

public class ClassificationProps : Entity
{
    
    [Column("idano")]
    public int? YearId { get; set; }
    
    [Column("idprofessor")]
    public int? TeacherId { get; set; }
    
    [Column("idinscricao")]
    public int? SubscriptionId { get; set; }
    
    [Column("nome")]
    public string? Name { get; set; }
    
    [Column("idsituacao")]
    public int? SituationId { get; set; }
    
    [Column("situacao")]
    public string? Situation { get; set; }
    
    [Column("idcargo")]
    public int? PositionId { get; set; }
    
    [Column("cargo")]
    public string? Position { get; set; }
    
    [Column("idunidade")]
    public int? UnitId { get; set; }
    
    [Column("unidade")]
    public string? Unit { get; set; }
    
    [Column("iddisciplina")]
    public int? DisciplineId { get; set; }
    
    [Column("disciplina")]
    public string? Discipline { get; set; }
    
    [Column("telefone")]
    public string? Phone { get; set; }
    
    [Column("celular")]
    public string? Cellphone { get; set; }
    
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

    [Column("t1")]
    public decimal? T1 { get; set; }

    [Column("t2")]
    public decimal? T2 { get; set; }

    [Column("t3")]
    public decimal? T3 { get; set; }

    [Column("t4")]
    public decimal? T4 { get; set; }

    [Column("t5")]
    public decimal? T5 { get; set; }

    [Column("t6")]
    public decimal? T6 { get; set; }

    [Column("t7")]
    public decimal? T7 { get; set; }

    [Column("t8")]
    public decimal? T8 { get; set; }

    [Column("t9")]
    public decimal? T9 { get; set; }

    [Column("t10")]
    public decimal? T10 { get; set; }

    [Column("t11")]
    public decimal? T11 { get; set; }

    [Column("t12")]
    public decimal? T12 { get; set; }

    [Column("t13")]
    public decimal? T13 { get; set; }

    [Column("t14")]
    public decimal? T14 { get; set; }

    [Column("t15")]
    public decimal? T15 { get; set; }

    [Column("t16")]
    public decimal? T16 { get; set; }

    [Column("t17")]
    public decimal? T17 { get; set; }

    [Column("t18")]
    public decimal? T18 { get; set; }

    [Column("t19")]
    public decimal? T19 { get; set; }

    [Column("t20")]
    public decimal? T20 { get; set; }

    [Column("t21")]
    public decimal? T21 { get; set; }

    [Column("t22")]
    public decimal? T22 { get; set; }

    [Column("total")]
    public decimal? Total { get; set; }
}
