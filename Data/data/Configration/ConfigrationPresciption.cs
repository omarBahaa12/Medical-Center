using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationPresciption : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.MedicationName).
                IsRequired();

            builder.Property(a => a.Dosage).
                IsRequired();

            builder.Property(m => m.StartDate).HasColumnType("date").IsRequired();
            builder.Property(m => m.EndDate).HasColumnType("date").IsRequired();

            builder.HasOne(M => M.MedicalRecords).WithMany(p => p.Prescriptions).
                HasForeignKey(M => M.MedicalRecordId).IsRequired();
            builder.HasIndex(a => a.MedicalRecordId).IsUnique();

            builder.ToTable("Prescriptions");

        }
    }
}
