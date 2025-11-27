using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("UsersUnits")]
public class UserUnit : UserUnitProps
{
    public UserUnit() 
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public UserUnit(UserUnitProps props) 
    {
        Assign(props);
    }

    public void Update(UserUnitProps props)
    {
        AssignUpdate(props);
    }
}

public class UserUnitProps : Entity
{
    [Required]
    [ForeignKey(nameof(User))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? UserId { get; set; }
    [Required]
    [ForeignKey(nameof(Unit))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? UnitId { get; set; }
}
