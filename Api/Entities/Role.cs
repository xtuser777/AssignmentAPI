using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("atr_groups")]
[PrimaryKey(nameof(RoleId))]
public class Role : RoleProps
{
    public Role()
    {

    }
}

public class RoleProps : Entity
{
    [Column("group_id")]
    public int? RoleId { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
