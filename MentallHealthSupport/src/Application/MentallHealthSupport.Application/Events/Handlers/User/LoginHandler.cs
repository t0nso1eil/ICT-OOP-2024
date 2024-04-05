using MediatR;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Events.Commands.User;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Entities;
using MentallHealthSupport.Application.Services.Auth;
using Microsoft.Extensions.Options;

namespace MentallHealthSupport.Application.Events.Handlers.User;

public class LoginHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher _passwordHasher;
    private readonly JwtProvider _jwtProvider;

    public LoginHandler(IUserRepository userRepository, IOptions<JwtOption> options)
    {
        _userRepository = userRepository;
        _passwordHasher = new PasswordHasher();
        _jwtProvider = new JwtProvider(options);
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(request.LoginRequest.Email);
        if (user is null)
        {
            throw new NotFoundException("This user doesn't exist.");
        }

        var result = _passwordHasher.Verify(request.LoginRequest.Password, user.PasswordHash);
        if (result == false)
        {
            throw new IncorrectInputException("Incorrect password");
        }

        return _jwtProvider.GenerateToken(user.Id);
    }
}