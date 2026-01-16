using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class TitlesService(IUnitOfWork unitOfWork) : ITitlesService
{
    public async Task<Title> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .TitlesRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.TitleNotFound);
    }

    public async Task<IEnumerable<Title>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.TitlesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TitlesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Title> CreateAsync(CreateServiceParams parameters)
    {
        var props = (TitleProps)parameters.Props;
        var title = new Title(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TitlesRepository.CreateAsync(title);
        await unitOfWork.Commit(transaction);
        return title;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (TitleProps)parameters.Props;
        var title = await FindOneAsync(parameters);
        title.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TitlesRepository.Update(title);
        await unitOfWork.Commit(transaction);
    }

    public async Task ImportAsync(int yearId)
    {
        var yearBefore = yearId - 1;
        var titlesToImport = await unitOfWork.TitlesRepository
            .FindManyAsync(new FindManyRepositoryParams
            {
                Where = new FindManyTitlesParams { YearId = yearBefore }
            });
        var importedTitles = titlesToImport
            .Select(title =>
            {
                var titleId = unitOfWork.TitlesRepository.GetId(t => t.TitleId).GetAwaiter().GetResult();
                var description = title.Description!.Replace(yearBefore.ToString(), yearId.ToString());
                var importedtitle = new Title
                {
                    TitleId = title.TitleId + titleId,
                    YearId = yearId,
                    Description = description,
                    Alias = title.Alias,
                    Order = title.Order,
                    Max = title.Max,
                    Weight = title.Weight,
                    Type = title.Type,
                    Active = title.Active
                };
                return importedtitle;
            })
            .ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TitlesRepository.CreateManyAsync(importedTitles);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var title = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TitlesRepository.Delete(title);
        await unitOfWork.Commit(transaction);
    }
}
