using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Resources.Messages;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class UsersService(
    IUnitOfWork unitOfWork, 
    ICryptService cryptService) : IUsersService
{
    public async Task<User> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork
            .UsersRepository
            .FindOneAsync(parameters)
            ?? throw new NotFoundException(Errors.UserNotFound);
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.UsersRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.UsersRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<User> CreateAsync(CreateServiceParams parameters)
    {
        var props = (UserProps)parameters.Props;
        var user = new User(props)
        {
            Password = cryptService.HashPassword(props.Password!)
        };
        var usersUnits = props.UsersUnits!.ToList();
        usersUnits.ForEach(userUnit => userUnit.UserId = user.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UsersRepository.CreateAsync(user);
        await unitOfWork.UsersUnitsRepository.CreateManyAsync([.. usersUnits]);
        await unitOfWork.Commit(transaction);
        return user;
    }

    public async Task UpdateAsync(UpdateServiceParams parameters)
    {
        var props = (UserProps)parameters.Props;
        var user = await FindOneAsync(parameters);
        if (props.Password is not null) 
            props.Password = cryptService.HashPassword(props.Password);
        user.Update(props);
        var usersUnits = props.UsersUnits!.ToList();
        usersUnits.ForEach(userUnit => userUnit.UserId = user.Id);
        await using var transaction = unitOfWork.BeginTransaction;
        unitOfWork.UsersRepository.Update(user);
        await unitOfWork.UsersUnitsRepository.DeleteManyAsync(
            new FindManyUsersUnitsParams { UserId = user.Id });
        await unitOfWork.UsersUnitsRepository.CreateManyAsync([.. usersUnits]);
        await unitOfWork.Commit(transaction);
    }

    public async Task DeleteAsync(DeleteServiceParams parameters)
    {
        var user = await FindOneAsync(parameters);
        await using var transaction = unitOfWork.BeginTransaction;
        await unitOfWork.UsersUnitsRepository.DeleteManyAsync(
            new FindManyUsersUnitsParams { UserId = user.Id });
        unitOfWork.UsersRepository.Delete(user);
        await unitOfWork.Commit(transaction);
    }
{
}
