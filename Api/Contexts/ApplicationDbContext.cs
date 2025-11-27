using Assignment.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Year> Years { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Situation> Situations { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<CivilStatus> CivilStatuses { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Teatcher> Teatchers { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<TitleBySubscription> TitlesBySubscriptions { get; set; }
    public DbSet<UserUnit> UsersUnits { get; set; }
    public DbSet<PointsBySubscription> PointsBySubscriptions { get; set; }
    public DbSet<Classification> Classifications { get; set; }
}
