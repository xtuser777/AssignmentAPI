namespace Assignment.Api.Entities;

public class Discipline : DisciplineProps
{
    public Discipline()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Discipline(DisciplineProps props)
    {
        Assign(props);
    }

    public void Update(DisciplineProps props)
    {
        AssignUpdate(props);
    }
}

public class DisciplineProps : Entity
{
    public string? Name { get; set; }
}
