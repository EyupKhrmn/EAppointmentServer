using EAppointmentServer.Domain.Entities;
using EAppointmentServer.Domain.Repositories;
using EAppointmentServer.Infrastructure.Context;
using GenericRepository;

namespace EAppointmentServer.Infrastructure.Repositories;

internal class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }
}