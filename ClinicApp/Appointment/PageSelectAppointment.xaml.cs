using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Appointment
{
    /// <summary>
    /// Interaction logic for PageSelectAppointment.xaml
    /// </summary>
    public partial class PageSelectAppointment : Page
    {
        public DateTime AppointmentDate { get; private set; }
        public string? DoctorName { get; private set; }

        public PageSelectAppointment()
        {
            InitializeComponent();
            ucDoctorBySpecialization1.GetDoctorName += UcDoctorBySpecialization1_GetDoctorName;
            ucDoctorBySpecialization1.GetDoctorName += ucSelectAppointment1.GetDoctorName;
            ucSelectAppointment1.ReturnAppointmentDate += UcSelectAppointment1_ReturnAppointmentDate;
            
        }

        public PageSelectAppointment(int doctorID, DateTime appointmentDate)
        {
            InitializeComponent();
            ucDoctorBySpecialization1.GetDoctorName += UcDoctorBySpecialization1_GetDoctorName;
            ucDoctorBySpecialization1.GetDoctorName += ucSelectAppointment1.GetDoctorName;
            ucSelectAppointment1.ReturnAppointmentDate += UcSelectAppointment1_ReturnAppointmentDate;
            ucDoctorBySpecialization1.SetDoctor(doctorID);
            ucSelectAppointment1.SetAppointment(appointmentDate);
            
        }

        private void UcSelectAppointment1_ReturnAppointmentDate(DateTime date)
        {
            this.AppointmentDate = date;
        }

        private void UcDoctorBySpecialization1_GetDoctorName(string? DoctorName)
        {
            this.DoctorName = DoctorName;
        }
    }
}
