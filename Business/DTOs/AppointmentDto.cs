using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Business.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? DoctorName { get; set; } 
        public string? PatientName { get; set; }
        public string? UserName { get; set; }
        public string? Resrvation { get; set; }
        public string? Status { get; set; } 

        public int StatusID { get; set; }

        public static List<AppointmentDto> GetAppointmentDtos()
        {
            return CrudExention.CreateDbContext().Appointments.Include(a => a.Doctor).
                ThenInclude(d => d.Specialization).Include(a => a.Patient).Include(a => a.User).Select(a =>      
                    new AppointmentDto
                    {
                        AppointmentID = a.ID,
                        DoctorName = a.Doctor.FullName,
                        PatientName = a.Patient.FullName,
                        UserName = a.User.UserName,
                        Resrvation=a.Doctor.Specialization.SpecializationName,
                        AppointmentDate = a.AppointmentDate,
                        Status=a.Appointmentstatus.Appointmentstatus
                    }
                ).ToList();
        }
        public static List<AppointmentDto> GetAppointmentDtos(int ID)
        {
            return CrudExention.CreateDbContext().Appointments.Where(a=>a.ID==ID).Include(a => a.Doctor).
                ThenInclude(d => d.Specialization).Include(a => a.Patient).Include(a => a.User).Select(a =>
                    new AppointmentDto
                    {
                        AppointmentID = a.ID,
                        DoctorName = a.Doctor.FullName,
                        PatientName = a.Patient.FullName,
                        UserName = a.User.UserName,
                        Resrvation = a.Doctor.Specialization.SpecializationName,
                        AppointmentDate = a.AppointmentDate,
                        Status = a.Appointmentstatus.Appointmentstatus
                    }
                ).ToList();
        }
        public static List<AppointmentDto> GetAppointmentDtos(string Name)
        {
            return CrudExention.CreateDbContext().Appointments.Where(a=>a.Patient.FullName.Substring(0,Name.Length)==Name).
                Include(a => a.Doctor).
                ThenInclude(d => d.Specialization).Include(a => a.Patient).Include(a => a.User).Select(a =>
                    new AppointmentDto
                    {
                        AppointmentID = a.ID,
                        DoctorName = a.Doctor.FullName,
                        PatientName = a.Patient.FullName,
                        UserName = a.User.UserName,
                        Resrvation = a.Doctor.Specialization.SpecializationName,
                        AppointmentDate = a.AppointmentDate,
                        Status = a.Appointmentstatus.Appointmentstatus
                    }
                ).ToList();
        }


        public static List<AppointmentDto> GetAppointmentDtosByPersonID(int ID)
        {
            var context = CrudExention.CreateDbContext();
            var Person =context.Persons.SingleOrDefault(p => p.ID == ID);
            if (Person is not null)
            {
                if (Person.TypeName == "Pat")
                {
                    return context.Appointments.Where(a => a.PatientID == ID).Include(a => a.Doctor).
                        ThenInclude(d => d.Specialization).Include(a => a.User).Select(a =>
                            new AppointmentDto
                            {
                                AppointmentID = a.ID,
                                DoctorName = a.Doctor.FullName,
                                PatientName = a.Patient.FullName,
                                UserName = a.User.UserName,
                                Resrvation = a.Doctor.Specialization.SpecializationName,
                                AppointmentDate = a.AppointmentDate,
                                Status = a.Appointmentstatus.Appointmentstatus
                            }
                        ).ToList();
                }
                else if (Person.TypeName == "Use")
                {
                    return context.Appointments.Where(a => a.UserID == ID).Include(a => a.Doctor).
                    ThenInclude(d => d.Specialization).Include(a => a.User).Select(a =>
                        new AppointmentDto
                        {
                            AppointmentID = a.ID,
                            DoctorName = a.Doctor.FullName,
                            PatientName = a.Patient.FullName,
                            Resrvation = a.Doctor.Specialization.SpecializationName,
                            AppointmentDate = a.AppointmentDate,
                            Status = a.Appointmentstatus.Appointmentstatus
                        }
                    ).ToList();
                }
                else
                {
                    return context.Appointments.Where(a => a.DoctorID == ID).Include(a => a.Doctor).
                    ThenInclude(d => d.Specialization).Include(a => a.User).Select(a =>
                        new AppointmentDto
                        {
                            AppointmentID = a.ID,
                            PatientName = a.Patient.FullName,
                            UserName = a.User.UserName,
                            Resrvation = a.Doctor.Specialization.SpecializationName,
                            AppointmentDate = a.AppointmentDate,
                            Status = a.Appointmentstatus.Appointmentstatus
                        }
                    ).ToList();
                }
            }
            else
            {
                return new List<AppointmentDto>();
            }
        }
        
        public static Appointment GetAppointment(int ID)
        {
            return CrudExention.CreateDbContext().Appointments.Include(a=>a.Patient).
                Include(a => a.Payment).Include(a=>a.Appointmentstatus).Include(a=>a.Doctor).ThenInclude(d=>d.Specialization).
                SingleOrDefault(a => a.ID == ID);
        }

        public static AppointmentDto GetAppointmentDto(int ID)
        {
            var context = CrudExention.CreateDbContext();
            try
            {
                var appointment=context.Appointments.Include(a => a.Patient).Include(a => a.Doctor).
                        ThenInclude(d => d.Specialization).Include(a => a.User).Select(a =>
                            new AppointmentDto
                            {
                                AppointmentID = a.ID,
                                PatientName = a.Patient.FullName,
                                DoctorName = a.Doctor.FullName,
                                UserName = a.User.UserName,
                                Resrvation = a.Doctor.Specialization.SpecializationName,
                                AppointmentDate = a.AppointmentDate,
                                StatusID = a.AppintmentStatusId
                            }
                        ).SingleOrDefault(a => a.AppointmentID == ID);
                return appointment!;
            }
            catch
            {
                return null!;
            }
        }
        
    }
}
