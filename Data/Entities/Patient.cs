using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Patient:Person
    {

        public Patient(string? fullName, DateTime dateBirth, bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2):
            base(fullName,  dateBirth,  gender, address, email,phone,  email2, phone2)
        {
            
        }
    }
}
