namespace Assignment.Api.Entities;

public class Preference : PreferenceProps
{
    public Preference()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Preference(PreferenceProps props)
    {
        Assign(props);
    }

    public void Update(PreferenceProps props)
    {
        AssignUpdate(props);
    }
}

public class PreferenceProps : Entity
{
    public string? Name { get; set; }
}
