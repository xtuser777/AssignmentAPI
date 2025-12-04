namespace Assignment.Api.Entities;

public class CivilStatus : CivilStatusProps
{
    public CivilStatus()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public CivilStatus(CivilStatusProps props)
    {
        Assign(props);
    }

    public void Update(CivilStatusProps props)
    {
        AssignUpdate(props);
    }
}

public class CivilStatusProps : Entity
{
    public string? Name { get; set; }
}
