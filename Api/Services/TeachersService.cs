using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
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

    public async Task ImportAsync(int yearId)
    {
        var yearBefore = yearId - 1;
        var teachersToImport = await unitOfWork.TeachersRepository
            .FindManyAsync(new FindManyRepositoryParams
            {
                Where = new FindManyTeachersParams
                {
                    YearId = yearBefore
                }
            });
        var importedTeachers = teachersToImport
            .Select(teacher =>
            {
                var teacherId = unitOfWork.TeachersRepository.GetId(t => t.TeacherId).GetAwaiter().GetResult();
                var impotedTeacher = new Teacher
                {
                    TeacherId = teacher.TeacherId + teacherId,
                    YearId = yearId,
                    Address = teacher.Address,
                    Email = teacher.Email,
                    Name = teacher.Name,
                    Phone = teacher.Phone,
                    PositionId = teacher.PositionId,
                    Adido = teacher.Adido,
                    AmbientalEdication = teacher.AmbientalEdication,
                    BirthAt = teacher.BirthAt,
                    Cellphone = teacher.Cellphone,
                    City = teacher.City,
                    CivilStatusId = teacher.CivilStatusId,
                    Computing = teacher.Computing,
                    Dependents = teacher.Dependents,
                    DisciplineId = teacher.DisciplineId,
                    Document = teacher.Document,
                    Identity = teacher.Identity,
                    Music = teacher.Music,
                    Neighborhood = teacher.Neighborhood,
                    Observations = teacher.Observations,
                    PostalCode = teacher.PostalCode,
                    Readapted = teacher.Readapted,
                    ReadingRoom = teacher.ReadingRoom,
                    Remove = teacher.Remove,
                    Robotics = teacher.Robotics,
                    SituationId = teacher.SituationId,
                    Speciality = teacher.Speciality,
                    SupplementCharge = teacher.SupplementCharge,
                    Tutoring = teacher.Tutoring,
                    UnitId = teacher.UnitId,
                };
                return impotedTeacher;
            })
            .ToList();
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.TeachersRepository.CreateManyAsync(importedTeachers);
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
