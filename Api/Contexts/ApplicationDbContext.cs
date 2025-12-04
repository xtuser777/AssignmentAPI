using Assignment.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<TitleBySubscription> TitlesBySubscriptions { get; set; }
    public DbSet<UserUnit> UsersUnits { get; set; }
    public DbSet<PointsBySubscription> PointsBySubscriptions { get; set; }
    public DbSet<Classification> Classifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Year
        modelBuilder.Entity<Year>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Year>()
            .Property(e => e.Record).HasMaxLength(250).IsRequired();
        modelBuilder.Entity<Year>()
            .Property(e => e.Resolution).HasMaxLength(250).IsRequired();
        modelBuilder.Entity<Year>()
            .Property(e => e.IsBlocked).IsRequired();

        // User
        modelBuilder.Entity<User>()
            .HasKey(e => new { e.Id, e.Username });
        modelBuilder.Entity<User>()
            .Property(e => e.Username).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<User>()
            .Property(e => e.Password).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<User>()
            .Property(e => e.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<User>()
            .Property(e => e.IsActive).IsRequired();
        modelBuilder.Entity<User>()
            .Property(e => e.Role).IsRequired();
        modelBuilder.Entity<User>()
            .HasMany(e => e.UsersUnits)
            .WithOne(e => e.User);
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Username).IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Name).IsUnique();
        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email).IsUnique();

        // Position
        modelBuilder.Entity<Position>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Position>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Position>()
            .Property(e => e.IsActive).IsRequired();
        modelBuilder.Entity<Position>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Position>()
            .HasIndex(e => e.Name).IsUnique();

        // Situation
        modelBuilder.Entity<Situation>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Situation>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Situation>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Situation>()
            .HasIndex(e => e.Name).IsUnique();

        // Unit
        modelBuilder.Entity<Unit>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Unit>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Unit>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Unit>()
            .HasIndex(e => e.Name).IsUnique();

        // UserUnit
        modelBuilder.Entity<UserUnit>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<UserUnit>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<UserUnit>()
            .HasOne(e => e.Unit)
            .WithMany()
            .HasForeignKey(e => e.UnitId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<UserUnit>()
            .HasOne(e => e.User)
            .WithMany(e => e.UsersUnits)
            .HasForeignKey(e => e.UserLogin)
            .HasPrincipalKey(e => e.Username)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Discipline
        modelBuilder.Entity<Discipline>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Discipline>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Discipline>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Discipline>()
            .HasIndex(e => e.Name).IsUnique();

        // Preference
        modelBuilder.Entity<Preference>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Preference>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Preference>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Preference>()
            .HasIndex(e => e.Name).IsUnique();

        // CivilStatus
        modelBuilder.Entity<CivilStatus>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<CivilStatus>()
            .Property(e => e.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<CivilStatus>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<CivilStatus>()
            .HasIndex(e => e.Name).IsUnique();

        //Title
        modelBuilder.Entity<Title>()
            .HasKey(e => new { e.Id, e.YearId });
        modelBuilder.Entity<Title>()
            .Property(e => e.Alias).HasMaxLength(10).IsRequired();
        modelBuilder.Entity<Title>()
            .Property(e => e.Description).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Title>()
            .Property(e => e.Weight).HasColumnType("decimal(12, 3)").IsRequired();
        modelBuilder.Entity<Title>()
            .Property(e => e.Max).HasColumnType("decimal(12, 3)").IsRequired();
        modelBuilder.Entity<Title>()
            .Property(e => e.Order).IsRequired();
        modelBuilder.Entity<Title>()
            .Property(e => e.IsActive).IsRequired();
        modelBuilder.Entity<Title>()
            .HasOne(e => e.Year)
            .WithMany()
            .HasForeignKey(e => e.YearId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Teacher
        modelBuilder.Entity<Teacher>()
            .HasKey(e => new { e.Id, e.YearId });
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Name).HasMaxLength(200).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Identity).HasMaxLength(12).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Document).HasMaxLength(11).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Dependents).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.BirthAt).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Address).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Neighborhood).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.City).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.PostalCode).HasMaxLength(8).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Phone).HasMaxLength(10).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Cellphone).HasMaxLength(11).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Observations).HasMaxLength(255);
        modelBuilder.Entity<Teacher>()
            .Property(e => e.Speciality).HasMaxLength(50);
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsRemove).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsAdido).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsReadapted).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsReadingRoom).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsComputing).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsSupplementCharge).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsTutoring).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsAmbientalEdication).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsRobotics).IsRequired();
        modelBuilder.Entity<Teacher>()
            .Property(e => e.IsMusic).IsRequired();
        modelBuilder.Entity<Teacher>()
            .HasIndex(e => e.Id);
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.Year)
            .WithMany()
            .HasForeignKey(e => e.YearId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.Unit)
            .WithMany()
            .HasForeignKey(e => e.UnitId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(); 
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.CivilStatus)
            .WithMany()
            .HasForeignKey(e => e.CivilStatusId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(); 
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.Position)
            .WithMany()
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(); 
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.Discipline)
            .WithMany()
            .HasForeignKey(e => e.DisciplineId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Teacher>()
            .HasOne(e => e.Situation)
            .WithMany()
            .HasForeignKey(e => e.SituationId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Subscription
        modelBuilder.Entity<Subscription>()
            .HasKey(e => new { e.Id, e.YearId, e.TeacherId });
        modelBuilder.Entity<Subscription>()
            .HasOne(e => e.Year)
            .WithMany()
            .HasForeignKey(e => e.YearId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Subscription>()
            .HasOne(e => e.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Subscription>()
            .HasOne(e => e.Preference)
            .WithMany()
            .HasForeignKey(e => e.PreferenceId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Subscription>()
            .HasMany(e => e.Titles)
            .WithOne()
            .HasForeignKey(e => e.SubscriptionId);
        modelBuilder.Entity<Subscription>()
            .HasMany(e => e.Points)
            .WithOne()
            .HasForeignKey(e => e.SubscriptionId);

        // TitleBySubscription
        modelBuilder.Entity<TitleBySubscription>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<TitleBySubscription>()
            .Property(e => e.Value).HasColumnType("decimal(12, 3)").IsRequired();
        modelBuilder.Entity<TitleBySubscription>()
            .HasOne(e => e.Title)
            .WithMany()
            .HasForeignKey(e => e.TitleId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<TitleBySubscription>()
            .HasOne(e => e.Year)
            .WithMany()
            .HasForeignKey(e => e.YearId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<TitleBySubscription>()
            .HasOne(e => e.Subscription)
            .WithMany(e => e.Titles)
            .HasForeignKey(e => e.SubscriptionId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<TitleBySubscription>()
            .HasOne(e => e.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // PointsBySubscription
        modelBuilder.Entity<PointsBySubscription>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<PointsBySubscription>()
            .Property(e => e.Description).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<PointsBySubscription>()
            .Property(e => e.Order).IsRequired();
        modelBuilder.Entity<PointsBySubscription>()
            .Property(e => e.Points)
            .HasColumnType("decimal(12, 3)")
            .IsRequired();
        modelBuilder.Entity<PointsBySubscription>()
            .HasOne(e => e.Year)
            .WithMany()
            .HasForeignKey(e => e.YearId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<PointsBySubscription>()
            .HasOne(e => e.Subscription)
            .WithMany(e => e.Points)
            .HasForeignKey(e => e.SubscriptionId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Classification
        modelBuilder.Entity<Classification>()
            .HasKey(e => e.Id);
    }
}
