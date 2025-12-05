using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("preferencia")]
[PrimaryKey(nameof(PreferenceId))]
public class Preference : PreferenceProps
{
    public Preference()
    {
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
    [Column("idpreferencia")]
    public int? PreferenceId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }
}
