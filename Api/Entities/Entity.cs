namespace Assignment.Api.Entities;

public class Entity
{
    protected void Assign(Entity entity)
    {
        var selfProperties = this.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            prop.SetValue(this, prop.GetValue(entity));
        }
    }

    protected void AssignUpdate(Entity entity)
    {
        var selfProperties = this.GetType().GetProperties();
        foreach (var prop in selfProperties)
        {
            if (prop.GetValue(entity) is not null)
                prop.SetValue(this, prop.GetValue(entity));
        }
    }
}
