using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("atr_users")]
[PrimaryKey(nameof(Username))]
public class User : UserProps
{
    public User()
    {
    }

    public User(UserProps props)
    {
        Assign(props);
    }

    public void Update(UserProps props)
    {
        AssignUpdate(props);
    }
}

public class UserProps : Entity
{
    [Column("login")]
    public string? Username { get; set; }

    [Column("pswd")]
    public string? Password { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("active")]
    public char? Active { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserRole>? UsersRoles { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UserUnit>? UsersUnits { get; set; }
}
