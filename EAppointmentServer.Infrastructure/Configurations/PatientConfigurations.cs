using EAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAppointmentServer.Infrastructure.Configurations;

public class PatientConfigurations : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(_ => _.FirstName).HasColumnType("varchar(50)");
        builder.Property(_ => _.LastName).HasColumnType("varchar(50)");
        builder.Property(_ => _.City).HasColumnType("varchar(50)");
        builder.Property(_ => _.Town).HasColumnType("varchar(50)");
        builder.Property(_ => _.FullAddress).HasColumnType("varchar(400)");
        builder.Property(_ => _.IdentityNumber).HasColumnType("varchar(11)");
        builder.HasIndex(_ => _.IdentityNumber).IsUnique();
    }
}