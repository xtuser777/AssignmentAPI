using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class SituationsService(IUnitOfWork unitOfWork) : ISituationsService
{
    public async Task<Situation> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .SituationsRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.SituationNotFound);
    }

    public async Task<IEnumerable<Situation>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.SituationsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.SituationsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Situation> CreateAsync(CreateServiceParams parameters)
    {
        var props = (SituationProps)parameters.Props;
        var situation = new Situation(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.SituationsRepository.CreateAsync(situation);
        await unitOfWork.Commit(transaction);
        return situation;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (SituationProps)parameters.Props;
        var situation = await FindOneAsync(parameters);
        situation.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SituationsRepository.Update(situation);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var situation = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.SituationsRepository.Delete(situation);
        await unitOfWork.Commit(transaction);
    }
}
