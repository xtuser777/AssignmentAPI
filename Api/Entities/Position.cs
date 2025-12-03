using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Positions")]
public class Position : PositionProps
{
    public Position() 
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Position(PositionProps props)
    {
        Assign(props);
    }

    public void Update(PositionProps props)
    {
        AssignUpdate(props);
    }
}

public class PositionProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    [Required]
    public bool? IsActive { get; set; }
}
