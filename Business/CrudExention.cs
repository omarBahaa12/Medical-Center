
using Data.data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Business
{
    public static class CrudExention
    {
        public static int AddInDatabase<TSource>(this TSource source,Func<TSource,int> predicate)
        {
            if (predicate is null)
                return 0;
            if (source is null)
                return 0;
            return predicate.Invoke(source);
            
        }
        public static bool UpdateInDatabase<TSource>(this TSource source,TSource source1 ,Func<TSource,TSource,bool> predicate)
        {
            if (predicate is null)
                return false;
            if (source is null)
                return false;
            return predicate.Invoke(source,source1);

        }

        public static bool DeleteInDatabase<TSource>(this TSource source ,Predicate<TSource> predicate)
        {
            if (predicate is null)
                return false;
            return predicate.Invoke(source);
        }
        public static AppDbContext CreateDbContext()
        {
            return new AppDbContext();
        }

        public static Patient CreatePatient(string? fullName, DateTime dateBirth,
            bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2)
        {
            return new Patient(fullName, dateBirth, gender, address, email, phone, email2, phone2);
        }

        public static User CreateUser(string?UserName,string?Password,string? fullName, 
            DateTime dateBirth, bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2)
        {
            return new User(UserName, Password, fullName, dateBirth, gender, address, email, phone, email2, phone2);
        }

        public static Doctor CreateDoctor(int SpecializationId, string? fullName,
            DateTime dateBirth, bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2)
        {
            return new Doctor(SpecializationId, fullName,dateBirth, gender, address, email,phone, email2, phone2);
        }
        public static List<string?> GetSpecializations()
        {
            using (var context = CreateDbContext())
            {
                return context.Specializations.Select(s => s.SpecializationName).ToList();
            }
        }

        public static List<string?> GetAppointmentStatus()
        {
            using (var context = CreateDbContext())
            {
                return context.AppointmentsStatus.Select(s => s.Appointmentstatus).ToList();
            }
        }
        public static List<string?> GetDoctorsBySpecialization(string? SpecializationName)
        {
            if (!string.IsNullOrWhiteSpace(SpecializationName))
            {
                using (var context = CreateDbContext())
                {
                    return context.Specializations.Include(s => s.Doctors).SingleOrDefault(s => s.SpecializationName == SpecializationName)
                        .Doctors.Select(d => d.FullName).ToList();
                }
            }
            return new List<string?>();
        }

        public static Appointment CreateAppointment(int patientID, int iD, int UserID, int AppointmentStatus, DateTime appointmentDate)
        {
            return new Appointment(patientID, iD, UserID, AppointmentStatus, appointmentDate);
        }

        public static Payment CreatePayment(int appointmentId, DateTime paymentDate, double amountPaid, string? paymentMethod)
        {
            return new Payment(appointmentId,paymentDate,amountPaid,paymentMethod);
        }
    }

}
