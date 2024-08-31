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
    public class SocialStatusConfiguration : IEntityTypeConfiguration<SocialStatus>
    {
        public void Configure(EntityTypeBuilder<SocialStatus> builder)
        {
            builder.ToTable("social_statuses");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion(
                    id => id.Id,
                    id => SocialStatusId.Create(id));

            builder.ComplexProperty(s => s.Status, sb =>
            {
                sb.Property(s => s.Value)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .IsRequired();
            });
        }
    }
}
