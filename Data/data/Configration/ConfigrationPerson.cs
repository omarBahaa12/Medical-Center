using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.data.Configration
{
    public class ConfigrationPerson : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();

            builder.Property(p => p.FullName).HasColumnType("nvarchar").HasMaxLength(25);
            builder.Property(p => p.FullName).IsRequired();


            builder.Property(p => p.DateBirth).HasDefaultValueSql("getdate()").IsRequired();


            builder.Property(p => p.Gender).IsRequired();


            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(p => p.Email).IsRequired();


            builder.Property(p => p.Address).HasColumnType("nvarchar").HasMaxLength(35);
            builder.Property(p => p.Address).IsRequired();


            builder.Property(p => p.Phone).HasColumnType("nvarchar").HasMaxLength(14);
            builder.Property(p => p.Phone).IsRequired();


            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(25);
            builder.Property(p => p.Email2).IsRequired(false);

            builder.Property(p => p.Phone).HasColumnType("nvarchar").HasMaxLength(14);
            builder.Property(p => p.Phone2).IsRequired(false);

            builder.HasDiscriminator<string>(p=>p.TypeName)
                .HasValue<Patient>("Pat")
                .HasValue<User>("Use")
                .HasValue<Doctor>("Doc");

            builder.Property(p=>p.TypeName).HasColumnType("varchar").HasMaxLength(3);
        }
    }
}
