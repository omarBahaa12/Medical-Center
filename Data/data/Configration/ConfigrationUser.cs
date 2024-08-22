using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.UserName).
                HasColumnType("varchar").HasMaxLength(20).
                IsRequired();

            builder.Property(u => u.Password).
                HasColumnType("varchar").HasMaxLength(20).
                IsRequired();

        }
    }
}
