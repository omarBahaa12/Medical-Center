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
    public class MedicalRecordsDto
    {
        public int ID { get; set; }

        public string? Diagnosis { get; set; }
        public string? Description { get; set; }
              
        public string? DoctorName { get; set; } 
        public string? Resrvation { get; set; } 
        public string? PatientName { get; set; }
        public string? Notes { get; set; }
        public string? UserName { get; set; } 
        public static List<MedicalRecordsDto> GetMedicalRecordsDtosByPeronID(int ID)
        {
            var context = CrudExention.CreateDbContext();
            var Person = context.Persons.SingleOrDefault(p => p.ID == ID);
            if (Person is not null)
            {
                if (Person.TypeName == "Pat")
                {
                    return context.MedicalRecords.Where(a => a.Appointment.PatientID == ID).Include(m=>m.Appointment)
                        .Include(a => a.Appointment.Doctor).
                        ThenInclude(d => d.Specialization).Include(a => a.Appointment.User).Select(a =>
                            new MedicalRecordsDto
                            {
                                ID = a.ID,
                                Description = a.Description,
                                Diagnosis = a.Diagnosis,
                                Notes = a.Notes,
                                DoctorName = a.Appointment.Doctor.FullName,
                                Resrvation = a.Appointment.Doctor.Specialization.SpecializationName,
                                UserName = a.Appointment.User.FullName
                            }
                        ).ToList();
                }

                else if (Person.TypeName == "Use")
                {
                    return context.MedicalRecords.Where(a => a.Appointment.UserID == ID).Include(m => m.Appointment)
                        .Include(a => a.Appointment.Patient).
                        Include(a => a.Appointment.Doctor).
                    ThenInclude(d => d.Specialization).Select(a =>
                        new MedicalRecordsDto
                        {
                            ID = a.ID,
                            Description = a.Description,
                            Diagnosis = a.Diagnosis,
                            Notes = a.Notes,
                            DoctorName = a.Appointment.Doctor.FullName,
                            Resrvation = a.Appointment.Doctor.Specialization.SpecializationName,
                            PatientName = a.Appointment.Patient.FullName
                        }
                    ).ToList();
                }

                else
                {
                    return context.MedicalRecords.Where(a => a.Appointment.DoctorID == ID).Include(m=>m.Appointment).
                        Include(a => a.Appointment.Patient)
                        .Include(a => a.Appointment.User).Select(a =>
                        new MedicalRecordsDto
                        {
                            ID = a.ID,
                            Description = a.Description,
                            Diagnosis = a.Diagnosis,
                            Notes = a.Notes,
                            PatientName = a.Appointment.Patient.FullName,
                            UserName = a.Appointment.User.FullName
                        }
                    ).ToList();
                }
            }
            else
            {
                return new List<MedicalRecordsDto>();
            }
        }

        public static List<MedicalRecordsDto> GetMedicalRecordsDtos()
        {
            var context = CrudExention.CreateDbContext();
            return context.MedicalRecords.Include(m=>m.Appointment).
                ThenInclude(a=>a.Doctor).ThenInclude(d=>d.Specialization).Include(m=>m.Appointment.Patient)
                .Select(m=>          
                    new MedicalRecordsDto
                    {
                        ID = m.ID,
                        PatientName = m.Appointment.Patient.FullName,
                        Diagnosis = m.Diagnosis,
                        Description = m.Description,
                        DoctorName = m.Appointment.Doctor.FullName,
                        Resrvation=m.Appointment.Doctor.Specialization.SpecializationName
                        
                    }
                ).ToList();
        }

        public static List<MedicalRecordsDto> GetMedicalRecordsDtos(int ID)
        {
            var context = CrudExention.CreateDbContext();
            return context.MedicalRecords.Where(m=>m.ID==ID).Include(m => m.Appointment).
                ThenInclude(a => a.Doctor).ThenInclude(d => d.Specialization).Include(m => m.Appointment.Patient)
                .Select(m =>
                    new MedicalRecordsDto
                    {
                        ID = m.ID,
                        PatientName = m.Appointment.Patient.FullName,
                        Diagnosis = m.Diagnosis,
                        Description = m.Description,
                        DoctorName = m.Appointment.Doctor.FullName,
                        Resrvation = m.Appointment.Doctor.Specialization.SpecializationName

                    }
                ).ToList();
        }

        public static List<MedicalRecordsDto> GetMedicalRecordsDtos(string text)
        {
            var context = CrudExention.CreateDbContext();
            return context.MedicalRecords.Where(m => m.Appointment.Patient.FullName.Substring(0,text.Length) == text)
                .Include(m => m.Appointment).
                ThenInclude(a => a.Doctor).ThenInclude(d => d.Specialization).Include(m => m.Appointment.Patient)
                .Select(m =>
                    new MedicalRecordsDto
                    {
                        ID = m.ID,
                        PatientName = m.Appointment.Patient.FullName,
                        Diagnosis = m.Diagnosis,
                        Description = m.Description,
                        DoctorName = m.Appointment.Doctor.FullName,
                        Resrvation = m.Appointment.Doctor.Specialization.SpecializationName

                    }
                ).ToList();
        }
    }
}
