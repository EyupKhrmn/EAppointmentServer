using EAppointmentServer.Domain.Entities;
using GenericRepository;

namespace EAppointmentServer.Domain.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
    
}