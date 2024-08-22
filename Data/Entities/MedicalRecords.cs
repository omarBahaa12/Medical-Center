using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public partial class MedicalRecords
    {
        public MedicalRecords(int iD, int AppointmentID, string? description, string? diagnosis, string? notes)
        {
            ID = iD;
            this.AppointmentID = AppointmentID;

            Description = description;
            Diagnosis = diagnosis;
            Notes = notes;
        }

        public int ID { get; set; }
        public int AppointmentID { get; set; }



        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }
        public Appointment Appointment { get; set; } = null!;
        public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
