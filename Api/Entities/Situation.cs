namespace Assignment.Api.Entities;

public class Situation : SituationProps
{
    public Situation()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Situation(SituationProps props)
    {
        Assign(props);
    }

    public void Update(SituationProps props)
    {
        AssignUpdate(props);
    }
}

public class SituationProps : Entity
{
    public string? Name { get; set; }
}
