using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Units")]
public class Unit : UnitProps
{
    public Unit()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Unit(UnitProps props)
    {
        Assign(props);
    }

    public void Update(UnitProps props)
    {
        AssignUpdate(props);
    }
}

public class UnitProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
