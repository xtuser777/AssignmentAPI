using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Years")]
public class Year : Entity
{
    public Year()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Year(YearProps props)
    {
        Assign(props);
    }

    public void Update(YearProps props)
    {
        AssignUpdate(props);
    }
}

public class YearProps : Entity
{
    [Required]
    public int? Value { get; set; }

    [Required]
    [StringLength(250)]
    public string? Record { get; set; }

    [Required]
    [StringLength(250)]
    public string? Resolution { get; set; }

    [Required]
    public bool? IsBlocked { get; set; }
}
