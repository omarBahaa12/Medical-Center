namespace Data.Entities
{
    public partial class AppointmentStatus
    {
        public int ID { get; }
        public string? Appointmentstatus { get; set; }

        public virtual List<Appointment> appointments { get; set; } = new List<Appointment>();

        public AppointmentStatus(int ID,string? appointmentstatus)
        {
            this.ID = ID;
            Appointmentstatus = appointmentstatus;
        }
    }
}
