using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Infrastructure.Mssql.Configurations
{
    public class AmbulanceRequestConfiguration : IEntityTypeConfiguration<AmbulanceRequest>
    {
        public void Configure(EntityTypeBuilder<AmbulanceRequest> builder)
        {
            builder.ToTable("ambulance_requests");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Id,
                    id => AmbulanceRequestId.Create(id));

            builder.ComplexProperty(x => x.RequestDateTime, builder =>
            {
                builder.IsRequired();

                builder.Property(x => x.Time)
                       .HasColumnName("time");
            });

            builder.HasOne(x => x.SickPerson)
                .WithMany(x => x.AmbulanceRequests)
                .HasForeignKey(x => x.SickPersonId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(x => x.CauseOfRecalls)
                .WithMany(c => c.AmbulanceRequests);

            builder.HasMany(x => x.ProcedurePerformeds)
                .WithOne(p => p.AmbulanceRequest)
                .HasForeignKey(c => c.AmbulanceRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
