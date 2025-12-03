using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("CivilStatuses")]
public class CivilStatus : CivilStatusProps
{
    public CivilStatus()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public CivilStatus(CivilStatusProps props)
    {
        Assign(props);
    }

    public void Update(CivilStatusProps props)
    {
        AssignUpdate(props);
    }
}

public class CivilStatusProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
