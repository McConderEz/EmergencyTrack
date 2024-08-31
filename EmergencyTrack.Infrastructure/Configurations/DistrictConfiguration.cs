using EmergencyTrack.Domain.Constraints;
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
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("disticts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasConversion(
                id => id.Id,
                id => DistrictId.Create(id));

            builder.ComplexProperty(d => d.Title, tb =>
            {
                tb.Property(t => t.Value)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("district_title")
                    .IsRequired();
            });

            builder.HasMany(d => d.EmergencyStations)
                .WithOne(e => e.District)
                .HasForeignKey(e => e.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
