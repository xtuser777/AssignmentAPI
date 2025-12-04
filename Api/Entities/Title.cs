namespace Assignment.Api.Entities;

public class Title: TitleProps
{
    public Title()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Title(TitleProps props)
    {
        Assign(props);
    }

    public void Update(TitleProps props)
    {
        AssignUpdate(props);
    }
}

public class TitleProps : Entity
{
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public bool? IsActive { get; set; }
    public int? YearId { get; set; }
    public Year? Year { get; set; }
}
