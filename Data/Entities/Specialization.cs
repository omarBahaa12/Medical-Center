using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public partial class Specialization
    {
        public int ID { get; set; }

        public Specialization(string? specializationName)
        {
            SpecializationName = specializationName;
        }

        public Specialization() { }
        public string? SpecializationName { get; set; }

        public virtual List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
