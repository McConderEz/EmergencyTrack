using EmergencyTrack.Domain.Constraints;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Infrastructure.Mssql.Configurations
{
    public class EmergencyStationConfiguration : IEntityTypeConfiguration<EmergencyStation>
    {
        public void Configure(EntityTypeBuilder<EmergencyStation> builder)
        {
            builder.ToTable("emergency_station");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasConversion(
                id => id.Id,
                id => EmergencyStationId.Create(id));

            builder.ComplexProperty(e => e.StationNumber, sb =>
            {
                sb.Property(s => s.Number)
                    .HasMaxLength(Constraints.STATION_NUMBER_LENGTH)
                    .HasColumnName("station_number")
                    .IsRequired();
            });

            builder.ComplexProperty(e => e.PhoneNumber, pb =>
            {
                pb.Property(s => s.Number)
                    .HasMaxLength(Constraints.MAX_PHONENUMBER_LENGTH)
                    .HasColumnName("phone_number")
                    .IsRequired();
            });

            builder.ComplexProperty(e => e.Address, ab =>
            {
                ab.Property(s => s.State)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("state")
                    .IsRequired();

                ab.Property(s => s.City)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("city")
                    .IsRequired();

                ab.Property(s => s.ZipCode)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("zip_code")
                    .IsRequired();

                ab.Property(s => s.Street)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("street")
                    .IsRequired();
            });

            builder.HasMany(e => e.AmbulanceRequests)
                .WithOne(a => a.EmergencyStation)
                .HasForeignKey(e => e.EmergencyStationId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
