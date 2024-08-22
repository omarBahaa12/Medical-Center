using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationDoctor : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasOne(d => d.Specialization).
                WithMany(s => s.Doctors).
                HasForeignKey(d => d.SpecializationId).
                IsRequired();
        }
    }
}
