using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationAppointmentStatus : IEntityTypeConfiguration<AppointmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.Appointmentstatus).
                IsRequired();

            builder.ToTable("AppointmentsStatus");

            builder.HasData(LoadAppointmentStatus());
        }

        private static List<AppointmentStatus> LoadAppointmentStatus()
        {
            return new List<AppointmentStatus>
            {
                new AppointmentStatus(1,"Pending"),
                new AppointmentStatus(2,"Confirmed"),
                new AppointmentStatus(3,"Completed"),
                new AppointmentStatus(4,"Canceled"),
                new AppointmentStatus(5,"Rescheduled"),
                new AppointmentStatus(6,"No Show")
            };
        }
    }
}
