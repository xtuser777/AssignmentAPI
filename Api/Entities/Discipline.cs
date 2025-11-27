using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Disciplines")]
public class Discipline : DisciplineProps
{
    public Discipline()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Discipline(DisciplineProps props)
    {
        Assign(props);
    }

    public void Update(DisciplineProps props)
    {
        AssignUpdate(props);
    }
}

public class DisciplineProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
