using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Situations")]
public class Situation : SituationProps
{
    public Situation()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Situation(SituationProps props)
    {
        Assign(props);
    }

    public void Update(SituationProps props)
    {
        AssignUpdate(props);
    }
}

public class SituationProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
