using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class YearsService(IUnitOfWork unitOfWork) : IYearsService
{
    public async Task<Year> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .YearsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.YearNotFound);
    }

    public async Task<IEnumerable<Year>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.YearsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.YearsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Year> CreateAsync(CreateServiceParams parameters)
    {
        var props = (YearProps)parameters.Props;
        var year = new Year(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.YearsRepository.CreateAsync(year);
        await unitOfWork.Commit(transaction);
        return year;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (YearProps)parameters.Props;
        var year = await FindOneAsync(parameters);
        year.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.YearsRepository.Update(year);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var year = await FindOneAsync(parameters);
        await CheckDependenciesAsync(year.YearId ?? 0);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.YearsRepository.Delete(year);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(int yearId)
    {
        await CheckTitleDependenciesAsync(yearId);
        await CheckTeacherDependenciesAsync(yearId);
        await CheckSubscriptionDependenciesAsync(yearId);
        await CheckImportDependenciesAsync(yearId);
    }

    private async Task CheckTitleDependenciesAsync(int yearId)
    {
        var titles = await unitOfWork
            .TitlesRepository
            .CountAsync(new CountTitlesParams { YearId = yearId });
        if (titles > 0)
        {
            throw new BadRequestException(
                $"O ano possui vínculo com {titles} títulos");
        }
    }

    private async Task CheckTeacherDependenciesAsync(int yearId)
    {
        var teachers = await unitOfWork
            .TeachersRepository
            .CountAsync(new CountTeachersParams { YearId = yearId });
        if (teachers > 0)
        {
            throw new BadRequestException(
                $"O ano possui vínculo com {teachers} professores");
        }
    }

    private async Task CheckSubscriptionDependenciesAsync(int yearId)
    {
        var subscriptions = await unitOfWork
            .SubscriptionsRepository
            .CountAsync(new CountSubscriptionsParams { YearId = yearId });
        if (subscriptions > 0)
        {
            throw new BadRequestException(
                $"O ano possui vínculo com {subscriptions} inscrições");
        }
    }

    private async Task CheckImportDependenciesAsync(int yearId)
    {
        var imports = await unitOfWork
            .ImportsRepository
            .CountAsync(new CountImportsParams { YearId = yearId });
        if (imports > 0)
        {
            throw new BadRequestException(
                $"O ano possui vínculo com {imports} importações");
        }
    }
}
