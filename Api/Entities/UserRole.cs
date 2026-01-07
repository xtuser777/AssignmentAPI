using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("atr_users_groups")]
[PrimaryKey(nameof(Username), nameof(RoleId))]
public class UserRole : UserRoleProps
{
    public UserRole() { }

    public UserRole(UserRoleProps props)
    {
        Assign(props);
    }
}

public class UserRoleProps : Entity
{
    [Column("login")]
    public string? Username { get; set; }

    [Column("group_id")]
    public int? RoleId { get; set; }

    [ForeignKey(nameof(RoleId))]
    public virtual Role? Role { get; set; }

    [ForeignKey(nameof(Username))]
    public virtual User? User { get; set; }
}
