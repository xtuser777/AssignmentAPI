namespace Assignment.Api.Entities;

public class Unit : UnitProps
{
    public Unit()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Unit(UnitProps props)
    {
        Assign(props);
    }

    public void Update(UnitProps props)
    {
        AssignUpdate(props);
    }
}

public class UnitProps : Entity
{
    public string? Name { get; set; }
}
