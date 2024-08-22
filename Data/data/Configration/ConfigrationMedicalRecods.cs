using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationMedicalRecords : IEntityTypeConfiguration<MedicalRecords>
    {
        public void Configure(EntityTypeBuilder<MedicalRecords> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Diagnosis).
                IsRequired();

            builder.Property(a => a.Description).
                IsRequired();


            builder.HasOne(M => M.Appointment).WithMany(a=>a.MedicalRecords)
                .HasForeignKey(M => M.AppointmentID).IsRequired();


            builder.ToTable("MedicalRecords");

        }
    }
}
