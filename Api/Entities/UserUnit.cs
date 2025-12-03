using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("UsersUnits")]
public class UserUnit : UserUnitProps
{
    public UserUnit() 
    {
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
    public int? UserId { get; set; }
    [Required]
    public int? UnitId { get; set; }

    [ForeignKey(nameof(UserId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public User? User { get; init; }

    [ForeignKey(nameof(UnitId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Unit? Unit { get; init; }
}
