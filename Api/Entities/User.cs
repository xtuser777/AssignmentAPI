using Assignment.Api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Users")]
public class User : UserProps
{
    public User()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
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
    [Required]
    [StringLength(50)]
    public string? Username { get; set; }   
    [Required]
    [StringLength(100)]
    public string? Password { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [Required]
    [StringLength(100)]
    public string? Email { get; set; }
    [Required]
    public bool? IsActive { get; set; }
    [Required]
    public UserRole? Role { get; set; }
}
