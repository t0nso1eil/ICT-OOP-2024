namespace MentallHealthSupport.Application.Services;

using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Models.Dto;

public class AuthenticationService : IAuthenticationService
{
    public Task Login(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task Registrate(RegistrateUserDto registrateUserDto)
    {
        throw new NotImplementedException();
    }
}