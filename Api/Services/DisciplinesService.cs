using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class DisciplinesService(IUnitOfWork unitOfWork) : IDisciplinesService
{
    public async Task<Discipline> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .DisciplinesRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.DisciplineNotFound);
    }

    public async Task<IEnumerable<Discipline>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.DisciplinesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.DisciplinesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Discipline> CreateAsync(CreateServiceParams parameters)
    {
        var props = (DisciplineProps)parameters.Props;
        var discipline = new Discipline(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.DisciplinesRepository.CreateAsync(discipline);
        await unitOfWork.Commit(transaction);
        return discipline;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (DisciplineProps)parameters.Props;
        var discipline = await FindOneAsync(parameters);
        discipline.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DisciplinesRepository.Update(discipline);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var discipline = await FindOneAsync(parameters);
        await CheckDependenciesAsync(discipline.DisciplineId ?? 0);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.DisciplinesRepository.Delete(discipline);
        await unitOfWork.Commit(transaction);
    }

    private async Task CheckDependenciesAsync(int disciplineId)
    {
        await CheckTeacherDependenciesAsync(disciplineId);
    }

    private async Task CheckTeacherDependenciesAsync(int disciplineId)
    {
        var teachers = await unitOfWork
            .TeachersRepository
            .CountAsync(new CountTeachersParams { DisciplineId = disciplineId });
        if (teachers > 0)
        {
            throw new BadRequestException(
                $"A disciplina possui vínculo com {teachers} professores");
        }
    }
}
