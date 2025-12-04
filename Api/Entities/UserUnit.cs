namespace Assignment.Api.Entities;

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
    public string? UserLogin { get; set; }
    public int? UnitId { get; set; }
    public User? User { get; init; }
    public Unit? Unit { get; init; }
}
