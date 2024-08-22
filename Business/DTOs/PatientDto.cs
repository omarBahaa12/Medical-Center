using Data.data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class PatientDto
    {
        private static AppDbContext context = CrudExention.CreateDbContext();

        public int ID { get; set; }
        public String? FullName { get; set; }
        public String? Phone { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public int AppointmentsCount { get; set; }
        public static List<PatientDto> GetPatientDtos()
        {
            return context.Set<Person>().OfType<Patient>().Include(p => p.Appointments).Select(p =>
               new PatientDto {
                   ID= p.ID,
                   FullName= p.FullName,
                   Phone= p.Phone,
                   Address= p.Address,
                   Email= p.Email,
                   AppointmentsCount= p.Appointments.Count
               }
                ).ToList();
        }
        public static List<PatientDto> GetPatientDtos(int ID)
        {
 
            return context.Set<Person>().OfType<Patient>().Include(p => p.Appointments).Where(p=>p.ID==ID).Select(p =>
               new PatientDto
               {
                   ID = p.ID,
                   FullName = p.FullName,
                   Phone = p.Phone,
                   Address = p.Address,
                   Email = p.Email,
                   AppointmentsCount = p.Appointments.Count
               }
                ).ToList();
        }
        public static List<PatientDto> GetPatientDtos(string FullName)
        {

            return context.Set<Person>().OfType<Patient>().Where(p => p.FullName.Substring(0, FullName.Length) == FullName)
                .Include(p => p.Appointments).Select(p =>
               new PatientDto
               {
                   ID = p.ID,
                   FullName = p.FullName,
                   Phone = p.Phone,
                   Address = p.Address,
                   Email = p.Email,
                   AppointmentsCount = p.Appointments.Count
               }
                ).ToList();
        }

        public static Person GetPerson(int ID)
        {
            return context.Persons.SingleOrDefault(p => p.ID == ID);
        }
    }
}
