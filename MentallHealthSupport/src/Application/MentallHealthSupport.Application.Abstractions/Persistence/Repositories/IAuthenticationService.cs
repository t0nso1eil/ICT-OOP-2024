namespace MentallHealthSupport.Application.Abstractions.Persistence.Repositories;

using MentallHealthSupport.Application.Models.Dto;

public interface IAuthenticationService
{
    public Task Login(LoginDto loginDto);

    public Task Registrate(RegistrateUserDto registrateUserDto);
}