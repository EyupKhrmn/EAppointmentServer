using EAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAppointmentServer.Infrastructure.Configurations;

internal class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(_ => _.FirstName).HasColumnType("varchar(50)");
        builder.Property(_ => _.LastName).HasColumnType("varchar(50)");
    }
}