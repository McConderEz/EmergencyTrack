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
    public class CauseOfRecallConfiguration : IEntityTypeConfiguration<CauseOfRecall>
    {
        public void Configure(EntityTypeBuilder<CauseOfRecall> builder)
        {
            builder.ToTable("cause_of_recall");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Id,
                    id => CauseOfRecallId.Create(id));

            builder.ComplexProperty(c => c.Cause, cb =>
            {
                cb.Property(c => c.Value)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("cause")
                    .IsRequired();
            });

        }
    }
}
