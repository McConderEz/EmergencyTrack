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
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("procedure");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Id,
                    id => ProcedureId.Create(id));

            builder.ComplexProperty(p => p.Title, tb =>
            {
                tb.Property(t => t.Value)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("procedure_title")
                    .IsRequired();
            });

            builder.HasMany(p => p.ProcedurePerformeds)
                .WithMany(p => p.Procedures);
                
        }
    }
}
