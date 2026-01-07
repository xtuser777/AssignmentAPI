using Assignment.Api.Contexts;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment.Api.Services;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private IYearsRepository? _yearsRepository = null;
    private IPositionsRepository? _positionsRepository = null;
    private IUsersRepository? _usersRepository = null;
    private IUsersUnitsRepository? _usersUnitsRepository = null;
    private IUnitsRepository? _unitsRepository = null;
    private IDisciplinesRepository? _disciplinesRepository = null;
    private ISituationsRepository? _situationsRepository = null;
    private ICivilStatusesRepository? _civilStatusesRepository = null;
    private ISubscriptionsRepository? _subscriptionsRepository = null;
    private IPreferencesRepository? _preferencesRepository = null;
    private IClassificationsRepository? _classificationsRepository = null;
    private ITitlesRepository? _titlesRepository = null;
    private ITeachersRepository? _teachersRepository = null;
    private ITitlesBySubscriptionsRepository? _titlesBySubscriptionsRepository = null;
    private IPointsBySubscriptionsRepository? _pointsBySubscriptionsRepository = null;
    private IRolesRepository? _rolesRepository = null;
    private IUsersRolesRepository? _usersRolesRepository = null;

    public ApplicationDbContext Context => context;
    public IDbContextTransaction BeginTransaction => context.Database.BeginTransaction();
    public IYearsRepository YearsRepository => _yearsRepository ?? new YearsRepository(context);
    public IPositionsRepository PositionsRepository => _positionsRepository ?? new PositionsRepository(context);
    public IUsersRepository UsersRepository => _usersRepository ?? new UsersRepository(context);
    public IUsersUnitsRepository UsersUnitsRepository => _usersUnitsRepository ?? new UsersUnitsRepository(context);
    public IUnitsRepository UnitsRepository => _unitsRepository ?? new UnitsRepository(context);
    public IDisciplinesRepository DisciplinesRepository => _disciplinesRepository ?? new DisciplinesRepository(context);
    public ISituationsRepository SituationsRepository => _situationsRepository ?? new SituationsRepository(context);
    public ICivilStatusesRepository CivilStatusesRepository => _civilStatusesRepository ?? new CivilStatusesRepository(context);
    public ISubscriptionsRepository SubscriptionsRepository => _subscriptionsRepository ?? new SubscriptionsRepository(context);
    public IPreferencesRepository PreferencesRepository => _preferencesRepository ?? new PreferencesRepository(context);
    public IClassificationsRepository ClassificationsRepository => _classificationsRepository ?? new ClassificationsRepository(context);
    public ITitlesRepository TitlesRepository => _titlesRepository ?? new TitlesRepository(context);
    public ITeachersRepository TeachersRepository => _teachersRepository ?? new TeachersRepository(context);
    public ITitlesBySubscriptionsRepository TitlesBySubscriptionsRepository => _titlesBySubscriptionsRepository ?? new TitlesBySubscriptionsRepository(context);
    public IPointsBySubscriptionsRepository PointsBySubscriptionsRepository => _pointsBySubscriptionsRepository ?? new PointsBySubscriptionsRepository(context);
    public IRolesRepository RolesRepository => _rolesRepository ?? new RolesRepository(context);
    public IUsersRolesRepository UsersRolesRepository => _usersRolesRepository ?? new UsersRolesRepository(context);

    public async Task Commit(IDbContextTransaction transaction, string? tableName = null)
    {
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
