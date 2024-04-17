using EAppointmentServer.Application.Services;
using EAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace EAppointmentServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand,Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.Users.FirstOrDefaultAsync(_ => _.UserName == request.UserNameOrEmail ||
                                                                         _.Email == request.UserNameOrEmail,cancellationToken);
        
        if(user is null) Result<LoginCommandResponse>.Failure("User Not Found");

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);
        
        if(!isPasswordCorrect) Result<LoginCommandResponse>.Failure("Password is incorrect");

        return Result<LoginCommandResponse>.Succeed(new(jwtProvider.CreateToken(user)));
    }
}