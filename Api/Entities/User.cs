using Assignment.Api.Enums;

namespace Assignment.Api.Entities;

public class User : UserProps
{
    public User()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public User(UserProps props)
    {
        Assign(props);
    }

    public void Update(UserProps props)
    {
        AssignUpdate(props);
    }
}

public class UserProps : Entity
{
    public string? Username { get; set; }   
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
    public UserRole? Role { get; set; }
    public ICollection<UserUnit>? UsersUnits { get; set; }
}
