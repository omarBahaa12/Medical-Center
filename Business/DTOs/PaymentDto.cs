using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Business.DTOs
{
    public class PaymentDto
    {
        public int ID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Patient { get; set; }
        

        public static List<PaymentDto> GetPaymentDtosByPersonID(int ID)
        {
            var context = CrudExention.CreateDbContext();

            return context.Payments.Where(a => a.Appointment.PatientID == ID).Include(a => a.Appointment)
                .Select(a =>
                    new PaymentDto
                    {
                        ID = a.ID,
                        PaymentDate = a.PaymentDate,
                        AmountPaid = a.AmountPaid,
                        AppointmentDate = a.Appointment.AppointmentDate
                    }
                ).ToList();
        }

        public static List<PaymentDto> GetPaymentDtos()
        {
            var context = CrudExention.CreateDbContext();

            return context.Payments.Include(a => a.Appointment).ThenInclude(a=>a.Patient)
                .Select(a =>
                    new PaymentDto
                    {
                        ID = a.ID,
                        Patient=a.Appointment.Patient.FullName!,
                        PaymentDate = a.PaymentDate,
                        AmountPaid = a.AmountPaid,
                        AppointmentDate = a.Appointment.AppointmentDate,
                        PaymentMethod = a.PaymentMethod,
                        AppointmentID=a.AppointmentId
                    }
                ).ToList();
        }

        public static List<PaymentDto> GetPaymentDtos(int ID)
        {
            var context = CrudExention.CreateDbContext();

            return context.Payments.Include(a => a.Appointment).ThenInclude(a => a.Patient)
                .Select(a =>
                    new PaymentDto
                    {
                        ID = a.ID,
                        Patient = a.Appointment.Patient.FullName!,
                        PaymentDate = a.PaymentDate,
                        AmountPaid = a.AmountPaid,
                        AppointmentDate = a.Appointment.AppointmentDate,
                        PaymentMethod = a.PaymentMethod,
                        AppointmentID = a.AppointmentId
                    }
                ).ToList();
        }

        public static PaymentDto GetPaymentDto(int ID)
        {
            var context = CrudExention.CreateDbContext();

            return context.Payments.Include(a => a.Appointment).ThenInclude(a => a.Patient)
                .Select(a =>
                    new PaymentDto
                    {
                        ID = a.ID,
                        Patient = a.Appointment.Patient.FullName!,
                        PaymentDate = a.PaymentDate,
                        AmountPaid = a.AmountPaid,
                        AppointmentDate = a.Appointment.AppointmentDate,
                        PaymentMethod = a.PaymentMethod,
                        AppointmentID=a.AppointmentId
                    }
                ).SingleOrDefault(p=>p.ID==ID);
        }

        public static List<PaymentDto> GetPaymentDtos(string text)
        {
            var context = CrudExention.CreateDbContext();

            return context.Payments.Where(p => p.Appointment.Patient.FullName.Substring(0,text.Length) == text)
                .Include(a => a.Appointment).ThenInclude(a => a.Patient)
                .Select(a =>
                    new PaymentDto
                    {
                        ID = a.ID,
                        Patient = a.Appointment.Patient.FullName!,
                        PaymentDate = a.PaymentDate,
                        AmountPaid = a.AmountPaid,
                        AppointmentDate = a.Appointment.AppointmentDate,
                        PaymentMethod = a.PaymentMethod
                    }
                ).ToList();
        }
    }

    
}
