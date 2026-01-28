using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;
using Microsoft.Identity.Client;

namespace Assignment.Api.Services;

public class ImportsService(
    IUnitOfWork unitOfWork) : IImportsService
{
    public async Task<Import> FindOneAsync(
        FindOneServiceParams parameters)
    {
        return await unitOfWork.ImportsRepository.FindOneAsync(new()
        {
            Where = parameters.Where,
            Includes = parameters.Includes
        }) ?? throw new NotFoundException("Importação não encontrada");
    }

    public async Task<IEnumerable<Import>> FindManyAsync(
        FindManyServiceParams parameters)
    {
        return await unitOfWork.ImportsRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.ImportsRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Import> CreateAsync(CreateServiceParams parameters)
    {
        var props = (ImportProps)parameters.Props;
        var import = new Import(props)
        {
            ImportId = await unitOfWork.ImportsRepository.GetId(x => x.ImportId)
        };
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.ImportsRepository.CreateAsync(import);
        await unitOfWork.Commit(transaction);
        return import;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (ImportProps)parameters.Props;
        var import = await FindOneAsync(new()
        {
            Where = parameters.Where
        });
        import.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.ImportsRepository.Update(import);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var import = await FindOneAsync(new()
        {
            Where = parameters.Where
        });
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.ImportsRepository.Delete(import);
        await unitOfWork.Commit(transaction);
    }

    public async Task<bool> ExistsAsync(ExistsServiceParams parameters)
    {
        return await unitOfWork.ImportsRepository.ExistsAsync(parameters.Where);
    }
}
