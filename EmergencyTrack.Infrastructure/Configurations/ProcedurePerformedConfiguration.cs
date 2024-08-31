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
    public class ProcedurePerformedConfiguration : IEntityTypeConfiguration<ProcedurePerformed>
    {
        public void Configure(EntityTypeBuilder<ProcedurePerformed> builder)
        {
            builder.ToTable("procedure_performeds");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Id,
                    id => ProcedurePerformedId.Create(id));

            builder.ComplexProperty(p => p.Price, pb =>
            {
                pb.Property(p => p.Value)
                    .HasColumnName("price")
                    .IsRequired();
            });

            
        }
    }
}
