using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationAppointment : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.AppointmentDate).
                IsRequired();


            builder.HasOne(a => a.Doctor).
                WithMany(p => p.Appointments).
                HasForeignKey(a => a.DoctorID).
                IsRequired();

            builder.HasOne(a => a.Patient).
                WithMany(p => p.Appointments).
                HasForeignKey(a => a.PatientID).
                IsRequired();

            builder.HasOne(a => a.User).
                WithMany(p => p.Appointments).
                HasForeignKey(a => a.UserID).
                IsRequired();

            builder.HasOne(a => a.Appointmentstatus).
                WithMany(As => As.appointments).
                HasForeignKey(a => a.AppintmentStatusId).
                IsRequired();

            builder.ToTable("Appointments");

        }
    }
}
