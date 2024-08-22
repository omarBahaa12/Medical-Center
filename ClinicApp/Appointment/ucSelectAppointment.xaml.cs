using Business;
using Business.DTOs;
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
    /// Interaction logic for SelectAppointment.xaml
    /// </summary>
    public partial class SelectAppointment : UserControl
    {
        public delegate void AppointmentDate(DateTime date);
        public event AppointmentDate ReturnAppointmentDate;
        public DateTime Appointment { get; private set; }

        private string DoctorName;
        public SelectAppointment()
        {
            InitializeComponent();
        }

        private void Date_Appointment_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment = Date_Appointment.SelectedDate.Value;
            if (DoctorDto.IsEmptyInThisDay(DoctorName, Appointment))
            {
                Appointment=DoctorDto.SetTime(DoctorName, Appointment);
                ReturnAppointmentDate?.Invoke(Appointment);
            }
            else
                MessageBox.Show("Error", "Schedule in this day busy", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        internal void GetDoctorName(string? DoctorName)
        {
            if (!string.IsNullOrWhiteSpace(DoctorName))
                this.DoctorName = DoctorName;
            else
                MessageBox.Show("Error", "Set Doctor First", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        internal void SetAppointment(DateTime appointmentDate)
        {
            Date_Appointment.SelectedDate = appointmentDate;
        }
    }
}
