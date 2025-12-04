namespace Assignment.Api.Entities;

public class Year : YearProps
{
    public Year()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Year(YearProps props)
    {
        Assign(props);
    }

    public void Update(YearProps props)
    {
        AssignUpdate(props);
    }
}

public class YearProps : Entity
{
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }
}
