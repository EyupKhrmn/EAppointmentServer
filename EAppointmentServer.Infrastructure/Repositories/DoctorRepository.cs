using EAppointmentServer.Domain.Entities;
using EAppointmentServer.Domain.Repositories;
using EAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace EAppointmentServer.Infrastructure.Repositories;

internal sealed class DoctorRepository : Repository<Doctor,ApplicationDbContext>, IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {
    }
}