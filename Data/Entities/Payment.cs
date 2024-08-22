using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Payment
    {
        public Payment(int appointmentId, DateTime paymentDate, double amountPaid, string? paymentMethod)
        {
            AppointmentId = appointmentId;
            PaymentDate = paymentDate;
            AmountPaid = amountPaid;
            PaymentMethod = paymentMethod;
        }

        public int ID { get; set; }
        public int AppointmentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }

        public Appointment Appointment { get; set; } = null!;

    }
}
