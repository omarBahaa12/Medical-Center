using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public partial class Appointment
    {
        public Appointment( int PatientID,int DoctorID,int UserID, int appintmentStatusId, DateTime appointmentDate)
        {
            this.PatientID = PatientID;
            this.DoctorID = DoctorID;
            this.UserID = UserID;
            AppintmentStatusId = appintmentStatusId;
            AppointmentDate = appointmentDate;
        }

        public int ID { get; }
        public int DoctorID { get; set; }

        public int PatientID { get; set; }
        public int UserID { get; set; }
        public int AppintmentStatusId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public AppointmentStatus Appointmentstatus { get; set; } = null!;
        public Payment? Payment { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
        public User User { get; set; } = null!;

        public virtual List<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
    }
}
