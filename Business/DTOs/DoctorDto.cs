using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class DoctorDto
    {
        public int ID { get; set; }
        public String? FullName { get; set; }
        public String? Phone { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public int AppointmentsCount { get; set; }
        public string? SpecializationName { get; set; } 
        public static List<DoctorDto> GetDoctorDtos()
        {
            return CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().
                Include(d=>d.Specialization).Include(d => d.Appointments).Select(d =>
            new DoctorDto
            {
                ID= d.ID,
                SpecializationName= d.Specialization.SpecializationName,
                FullName= d.FullName,
                Phone= d.Phone, 
                Address= d.Address,
                Email= d.Email,
                AppointmentsCount= d.Appointments.Count 
            }
            
            ).ToList();
        }
        public static List<DoctorDto> GetDoctorDtos(int ID)
        {
            return CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().
                Include(d => d.Specialization).Include(d => d.Appointments).Where(d=>d.ID==ID).Select(d =>
            new DoctorDto
            {
                ID = d.ID,
                SpecializationName = d.Specialization.SpecializationName,
                FullName = d.FullName,
                Phone = d.Phone,
                Address = d.Address,
                Email = d.Email,
                AppointmentsCount = d.Appointments.Count
            }

            ).ToList();
        }
        public static Doctor? GetDoctorbyName(string DoctorName)
        {
            return CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().FirstOrDefault(d => d.FullName == DoctorName);
        }
        public static bool IsEmptyInThisDay(string DoctorName,DateTime date)
        {
            var count= CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().Include(d => d.Appointments).
                FirstOrDefault(d => d.FullName == DoctorName).Appointments.
                Where(a => a.AppointmentDate.Month == date.Month && a.AppointmentDate.Day == date.Day).Count();
            if (count < 16)
                return true;
            return false;
           
        }
        public static DateTime SetTime(string DoctorName, DateTime date)
        {
            var Appointment = CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().Include(d => d.Appointments).
                FirstOrDefault(d => d.FullName == DoctorName).Appointments.
                Where(a => a.AppointmentDate.Month == date.Month && a.AppointmentDate.Day == date.Day).LastOrDefault();
            if (Appointment == null)
            {
                date=date.AddHours(8);
                return date;
            }
            else
            {
                date = date.AddHours(Appointment.AppointmentDate.Hour);
                date = date.AddMinutes(Appointment.AppointmentDate.Minute+ 30);
                return date;
            }
        }

        public static Doctor? GetDoctorbyID(int doctorID)
        {
            return CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>()
                .Include(d=>d.Appointments).Include(d=>d.MedicalRecods).Include(d=>d.Specialization).
                SingleOrDefault(d => d.ID ==doctorID);

        }

        public static List<DoctorDto> GetDoctorDtos(string text)
        {
            return CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().Where(d => d.FullName.Substring(0,text.Length) == text).
                Include(d => d.Specialization).Include(d => d.Appointments).Select(d =>
            new DoctorDto
            {
                ID = d.ID,
                SpecializationName = d.Specialization.SpecializationName,
                FullName = d.FullName,
                Phone = d.Phone,
                Address = d.Address,
                Email = d.Email,
                AppointmentsCount = d.Appointments.Count
            }

            ).ToList();
        }
    }
}
