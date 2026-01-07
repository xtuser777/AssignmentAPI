using Assignment.Api.Entities;
using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Utils;

namespace Assignment.Api.Services;

public class RolesService(IUnitOfWork unitOfWork) : IRolesService
{
    public Task<Role> CreateAsync(CreateServiceParams parameters)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeleteServiceParams parameters)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Role>> FindManyAsync(FindManyServiceParams parameters)
    {
        return await unitOfWork.RolesRepository.FindManyAsync(parameters);
    }

    public async Task<PaginationModel?> FindManyPaginationAsync(FindManyPaginationServiceParams parameters)
    {
        var count = await unitOfWork.RolesRepository.CountAsync(parameters.CountProps);
        return Pagination.Build(parameters.PaginationParams, count);
    }

    public async Task<Role> FindOneAsync(FindOneServiceParams parameters)
    {
        return await unitOfWork.RolesRepository.FindOneAsync(parameters) ?? throw new NotFoundException("Perfil não encontrado.");
    }

    public Task UpdateAsync(UpdateServiceParams parameters)
    {
        throw new NotImplementedException();
    }
}
