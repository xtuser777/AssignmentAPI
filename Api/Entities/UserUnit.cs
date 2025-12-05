using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("usuario_unidade")]
[PrimaryKey(nameof(UserLogin), nameof(UnitId))]
public class UserUnit : UserUnitProps
{
    public UserUnit() 
    {
    }

    public UserUnit(UserUnitProps props) 
    {
        Assign(props);
    }

    public void Update(UserUnitProps props)
    {
        AssignUpdate(props);
    }
}

public class UserUnitProps : Entity
{
    [Column("login")]
    public string? UserLogin { get; set; }

    [Column("idunidade")]
    public int? UnitId { get; set; }

    [ForeignKey(nameof(UserLogin))]
    public virtual User? User { get; init; }

    [ForeignKey(nameof(UnitId))]
    public virtual Unit? Unit { get; init; }
}
