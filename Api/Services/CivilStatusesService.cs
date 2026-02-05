using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class CivilStatusesService(IUnitOfWork unitOfWork) : ICivilStatusesService
{
    public async Task<CivilStatus> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .CivilStatusesRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.CivilStatusNotFound);
    }

    public async Task<IEnumerable<CivilStatus>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.CivilStatusesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.CivilStatusesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<CivilStatus> CreateAsync(CreateServiceParams parameters)
    {
        var props = (CivilStatusProps)parameters.Props;
        var status = new CivilStatus(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.CivilStatusesRepository.CreateAsync(status);
        await unitOfWork.Commit(transaction);
        return status;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (CivilStatusProps)parameters.Props;
        var status = await FindOneAsync(parameters);
        status.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.CivilStatusesRepository.Update(status);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var status = await FindOneAsync(parameters);
        await CheckDependenciesAsync(status.CivilStatusId ?? 0);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.CivilStatusesRepository.Delete(status);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(int civilStatusId)
    {
        await CheckTeacherDependenciesAsync(civilStatusId);
    }

    private async Task CheckTeacherDependenciesAsync(int civilStatusId)
    {
        var teachers = await unitOfWork
            .TeachersRepository
            .CountAsync(new CountTeachersParams { CivilStatusId = civilStatusId });
        if (teachers > 0)
        {
            throw new BadRequestException(
                $"O estado civil possui vínculo com {teachers} professores");
        }
    }
}
