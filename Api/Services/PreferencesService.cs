using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class PreferencesService(IUnitOfWork unitOfWork) : IPreferencesService
{
    public async Task<Preference> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .PreferencesRepository
            .FindOneAsync(parameters)
            ?? throw new NullReferenceException();
    }

    public async Task<IEnumerable<Preference>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.PreferencesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.PreferencesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Preference> CreateAsync(CreateServiceParams parameters)
    {
        var props = (PreferenceProps)parameters.Props;
        var preference = new Preference(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.PreferencesRepository.CreateAsync(preference);
        await unitOfWork.Commit(transaction);
        return preference;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (PreferenceProps)parameters.Props;
        var preference = await FindOneAsync(parameters);
        preference.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PreferencesRepository.Update(preference);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var preference = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.PreferencesRepository.Delete(preference);
        await unitOfWork.Commit(transaction);
    }
}
