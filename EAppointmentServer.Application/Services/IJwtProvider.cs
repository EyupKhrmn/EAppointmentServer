using EAppointmentServer.Domain.Entities;

namespace EAppointmentServer.Application.Services;

public interface IJwtProvider
{
    string CreateToken(AppUser user);
}