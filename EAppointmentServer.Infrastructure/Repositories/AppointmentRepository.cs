using EAppointmentServer.Domain.Entities;
using EAppointmentServer.Domain.Repositories;
using EAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace EAppointmentServer.Infrastructure.Repositories;

internal sealed class AppointmentRepository : Repository<Appointment,ApplicationDbContext>, IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}