namespace Assignment.Api.Entities;

public class Position : PositionProps
{
    public Position() 
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Position(PositionProps props)
    {
        Assign(props);
    }

    public void Update(PositionProps props)
    {
        AssignUpdate(props);
    }
}

public class PositionProps : Entity
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}
