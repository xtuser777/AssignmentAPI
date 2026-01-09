using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Repositories;
using Assignment.Api.Resources.Messages;

namespace Assignment.Api.Services;

public class AuthService(
    ICryptService cryptService,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    IConfiguration configuration) : IAuthService
{
    public async Task<string> Login(string username, string password, int yearId)
    {
        var user = await Validate(username, password);
        // var permissions = await Permissions(user.RoleId ?? Guid.Empty);

        var payload = new LoginPayload()
        {
            Sub = user.Username!,
            User = user.Name ?? "",
            Role = user.UsersRoles?.ToList()[0].RoleId?.ToString() ?? "",
            Year = yearId.ToString(),
        };

        var key = configuration["Jwt:Key"] ?? "";
        var issuer = configuration["Jwt:Issuer"] ?? "";
        var audience = configuration["Jwt:Audience"] ?? "";
        var token = tokenService.GenerateToken(
            key,
            issuer,
            audience,
            payload
        );

        return token;
    }

    //private async Task<List<string>> Permissions(Guid roleId)
    //{
    //    var role = await unitOfWork.RolesRepository.FindOneAsync(new() { 
    //        Id = roleId, 
    //        Includes = new IncludesRolesParams() { 
    //            RolesPages = new() {
    //                Page = true 
    //            } 
    //        } 
    //    }) 
    //        ?? throw new UnauthorizedAccessException(Errors.ROLE_NOT_FOUND);
    //    if ((bool)(!role.Active)!)
    //    {
    //        throw new UnauthorizedAccessException(Errors.AUTH_ROLE_INACTIVE);
    //    }

    //    List<Guid> pagesIds = role.RolesPages != null ? [
    //        .. role.RolesPages.Select(x => x.PageId ?? Guid.Empty)] : [];

    //    List<Page?> pages = [];
    //    foreach (var pageId in pagesIds)
    //    {
    //        var page = await unitOfWork.PagesRepository.FindOneAsync(
    //            new FindOneRepositoryParams() { Id = pageId });
    //        pages.Add(page);
    //    }

    //    List<string> permissions = [
    //        .. pages.Where(x => x != null).Select(x => x!.Name)];

    //    return permissions;
    //}

    private async Task<Entities.User> Validate(string username, string password)
    {
        var user = await ((UsersRepository)unitOfWork.UsersRepository)
                       .FindOneAsync(
            new FindOneRepositoryParams
            {
                Where = new FindManyUsersParams { Username = username },
                Includes = new IncludesUsersParams { UsersRoles = new IncludesUsersUsersRolesParams { Role = true } }
            })
            ?? throw new UnauthorizedAccessException(Errors.AuthInvalidUsername);
        if (user.Active != 'Y')
        {
            throw new UnauthorizedAccessException(Errors.AuthInactiveUser);
        }
        return !cryptService.VerifyHashedPassword(user.Password!, password)
            ? throw new UnauthorizedAccessException(Errors.AuthInvalidPassword)
            : user;
    }
}
