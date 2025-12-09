using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class TeachersService(IUnitOfWork unitOfWork) : ITeachersService
{
    public async Task<Teacher> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .TeachersRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.TeacherNotFound);
    }

    public async Task<IEnumerable<Teacher>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.TeachersRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.TeachersRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Teacher> CreateAsync(CreateServiceParams parameters)
    {
        var props = (TeacherProps)parameters.Props;
        var teacher = new Teacher(props);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TeachersRepository.CreateAsync(teacher);
        await unitOfWork.Commit(transaction);
        return teacher;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (TeacherProps)parameters.Props;
        var teacher = await FindOneAsync(parameters);
        teacher.Update(props);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TeachersRepository.Update(teacher);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var teacher = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.TeachersRepository.Delete(teacher);
        await unitOfWork.Commit(transaction);
    }
}
