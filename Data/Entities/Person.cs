using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Person
    {
        public readonly int ID;

        public string? FullName { get; set; }

        public DateTime DateBirth { get; set; }

        public bool Gender { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Email2 { get; set; }

        public string? Phone2 { get; set; }
        public Person(string? fullName, DateTime dateBirth, bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2)
        {
            FullName = fullName;
            DateBirth = dateBirth;
            Gender = gender;
            Address = address;
            Email = email;
            Phone = phone;
            Email2 = email2;
            Phone2 = phone2;
        }
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual List<MedicalRecords> MedicalRecods { get; set; } = new List<MedicalRecords>();
        public string TypeName { get; internal set; }
    }
}
