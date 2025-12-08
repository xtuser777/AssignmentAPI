using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class CivilStatusesService(IUnitOfWork unitOfWork) : ICivilStatusesService
{
    public async Task<CivilStatus> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .CivilStatusesRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException("Civil status not found");
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
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.CivilStatusesRepository.Delete(status);
        await unitOfWork.Commit(transaction);
    }
}
