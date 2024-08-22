using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.data.Configration
{
    public class ConfigrationPayment : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.PaymentMethod).
                HasColumnType("VARCHAR").HasMaxLength(10).
                IsRequired();

            builder.Property(a => a.PaymentDate).
                IsRequired();

            builder.HasOne(p => p.Appointment).WithOne(A => A.Payment).
                HasForeignKey<Payment>(p=>p.AppointmentId);
            builder.HasIndex(a => a.AppointmentId).IsUnique();


            builder.ToTable("Payments");

        }
    }
}
