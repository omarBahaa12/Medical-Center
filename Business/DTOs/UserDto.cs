using Data.data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Business.DTOs
{
    public class UserDto
    {
        private static AppDbContext context = CrudExention.CreateDbContext();

        public int ID { get; set; }
        public String? FullName { get; set; }
        public String? Phone { get; set; }
        public String? Address { get; set; }
        public string? Email { get; set; }
        public int AppointmentsCount { get; set; }

        public string? UserName { get; set; }
        public static List<UserDto> GetUserDtos()
        {
            return context.Set<Person>().OfType<User>().Include(u => u.Appointments).Select(u =>
               new UserDto
               {                  
                   ID= u.ID,
                   FullName= u.FullName,
                   Phone= u.Phone,
                   Address= u.Address,
                   Email= u.Email,
                   UserName = u.UserName,
                   AppointmentsCount = u.Appointments.Count 
               }
               
                ).ToList();
        }
        public static List<UserDto> GetUserDto(int ID)
        {
            return context.Set<Person>().OfType<User>().Include(u => u.Appointments).Where(u=>u.ID==ID).Select(u =>
               new UserDto
               {
                   ID = u.ID,
                   FullName = u.FullName,
                   Phone = u.Phone,
                   Address = u.Address,
                   Email = u.Email,
                   UserName = u.UserName,
                   AppointmentsCount = u.Appointments.Count
               }

                ).ToList();
        }
        public static User GetUserDtos(int iD)
        {
            return context.Set<Person>().OfType<User>().Include(u => u.Appointments).
                Include(u => u.MedicalRecods).SingleOrDefault(u => u.ID == iD);
        }

        public static List<UserDto> GetUserDto(string text)
        {
            return context.Set<Person>().OfType<User>().Where(u => u.FullName.Substring(0,text.Length) == text).
                Include(u => u.Appointments).Select(u =>
               new UserDto
               {
                   ID = u.ID,
                   FullName = u.FullName,
                   Phone = u.Phone,
                   Address = u.Address,
                   Email = u.Email,
                   UserName = u.UserName,
                   AppointmentsCount = u.Appointments.Count
               }

                ).ToList();
        }
    }
}
