using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Preferences")]
public class Preference : PreferenceProps
{
    public Preference()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Preference(PreferenceProps props)
    {
        Assign(props);
    }

    public void Update(PreferenceProps props)
    {
        AssignUpdate(props);
    }
}

public class PreferenceProps : Entity
{
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
}
