using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Doctor:Person
    {
        public Doctor(int specializationId,string? fullName, DateTime dateBirth, bool gender, string? address, string? email,
            string? phone, string? email2, string? phone2):
            base( fullName,  dateBirth,  gender, address,email,phone,email2,  phone2)
        {
            SpecializationId = specializationId;
        }

        public  int SpecializationId { get;  set; }
        public Specialization Specialization { get; private set; } = null!;

    }
}
