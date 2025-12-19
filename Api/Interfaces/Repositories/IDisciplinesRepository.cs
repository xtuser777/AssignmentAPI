using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IDisciplinesRepository : IRepository<Discipline>
{
}

public class FindManyDisciplinesParams : DisciplineProps;

public class CountDisciplinesParams : FindManyDisciplinesParams;

public class ExistsDisciplinesParams : CountDisciplinesParams;

public class ExclusiveDisciplinesParams : CountDisciplinesParams
{
    public int ExcludeDisciplineId { get; set; }
}

public record OrderByDisciplinesParams : OrderByParams
{
    public string? Name { get; set; }
}
