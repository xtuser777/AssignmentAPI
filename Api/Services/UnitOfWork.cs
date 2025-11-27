using Assignment.Api.Contexts;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assignment.Api.Services;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private IYearsRepository? _yearsRepository;
    private IPositionsRepository? _positionsRepository;
    private IUsersRepository? _usersRepository;
    private IUsersUnitsRepository? _usersUnitsRepository;
    private IUnitsRepository? _unitsRepository;
    private IDisciplinesRepository? _disciplinesRepository;
    private ISituationsRepository? _situationsRepository;
    private ICivilStatusesRepository? _civilStatusesRepository;
    private ISubscriptionsRepository? _subscriptionsRepository;
    private IPreferencesRepository? _preferencesRepository;
    private IClassificationsRepository? _classificationsRepository;
    private ITitlesRepository? _titlesRepository;
    private ITeatchersRepository? _teatchersRepository;
    private ITitlesBySubscriptionsRepository? _titlesBySubscriptionsRepository;
    private IPointsBySubscriptionsRepository? _pointsBySubscriptionsRepository;

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
    public ITeatchersRepository TeatchersRepository => _teatchersRepository ?? new TeatchersRepository(context);
    public ITitlesBySubscriptionsRepository TitlesBySubscriptionsRepository => _titlesBySubscriptionsRepository ?? new TitlesBySubscriptionsRepository(context);
    public IPointsBySubscriptionsRepository PointsBySubscriptionsRepository => _pointsBySubscriptionsRepository ?? new PointsBySubscriptionsRepository(context);

    public async Task Commit(IDbContextTransaction transaction)
    {
        await context.SaveChangesAsync();
        await transaction.CommitAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
