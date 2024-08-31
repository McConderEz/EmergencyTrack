using EmergencyTrack.Domain.Constraints;
using EmergencyTrack.Domain.Models;
using EmergencyTrack.Domain.Shared.Ids;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyTrack.Infrastructure.Mssql.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<City> builder)
        {
            builder.ToTable("city");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasConversion(
                    id => id.Id,
                    id => CityId.Create(id));

            builder.ComplexProperty(c => c.Title, cb =>
            {
                cb.Property(c => c.Value)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("city_title")
                    .IsRequired();
            });

            builder.HasMany(c => c.Districts)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
