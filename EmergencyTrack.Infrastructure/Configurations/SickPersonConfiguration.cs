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
    public class SickPersonConfiguration : IEntityTypeConfiguration<SickPerson>
    {
        public void Configure(EntityTypeBuilder<SickPerson> builder)
        {
            builder.ToTable("sick_persons");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasConversion(
                    id => id.Id,
                    id => SickPersonId.Create(id));

            builder.ComplexProperty(s => s.FullName, fb =>
            {
                fb.Property(f => f.FirstName)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("first_name")
                    .IsRequired();

                fb.Property(f => f.SecondName)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("second_name")
                    .IsRequired();

                fb.Property(f => f.Patronymic)
                    .HasMaxLength(Constraints.MAX_VALUE_LENGTH)
                    .HasColumnName("patronymic")
                    .IsRequired();
            });


            builder.ComplexProperty(s => s.BirthDate, bb =>
            {
                bb.Property(b => b.Date)
                    .HasColumnName("birth_date")
                    .IsRequired();

            });

            builder.ComplexProperty(s => s.PhoneNumber, pb =>
            {
                pb.Property(s => s.Number)
                    .HasMaxLength(Constraints.MAX_PHONENUMBER_LENGTH)
                    .HasColumnName("phone_number")
                    .IsRequired();
            });

            builder.ComplexProperty(s => s.Address, ab =>
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

            builder.HasOne(s => s.SocialStatus)
                .WithMany(s => s.SickPersons)
                .HasForeignKey(s => s.SocialStatusId)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
