using Assignment.Api.Contexts;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment.Api.Interfaces.Services;

public interface IUnitOfWork
{
    ApplicationDbContext Context { get; }
    IDbContextTransaction BeginTransaction { get; }
    IYearsRepository YearsRepository { get; }
    IPositionsRepository PositionsRepository { get; }
    IUsersRepository UsersRepository { get; }
    IUsersUnitsRepository UsersUnitsRepository { get; }
    IUnitsRepository UnitsRepository { get; }
    IDisciplinesRepository DisciplinesRepository { get; }
    ISituationsRepository SituationsRepository { get; }
    ISubscriptionsRepository SubscriptionsRepository { get; }
    IClassificationsRepository ClassificationsRepository { get; }
    ITitlesRepository TitlesRepository { get; }
    ITeatchersRepository TeatchersRepository { get; }
    ICivilStatusesRepository CivilStatusesRepository { get; }
    IPreferencesRepository PreferencesRepository { get; }
    ITitlesBySubscriptionsRepository TitlesBySubscriptionsRepository { get; }
    IPointsBySubscriptionsRepository PointsBySubscriptionsRepository { get; }
    Task Commit(IDbContextTransaction transaction);
    void Dispose();
}
