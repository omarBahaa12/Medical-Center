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
using System.Windows.Shapes;

namespace UI.Appointment
{
    /// <summary>
    /// Interaction logic for AppointmentInfo.xaml
    /// </summary>
    public partial class AppointmentInfo : Window
    {
        public AppointmentInfo(int ID)
        {
            InitializeComponent();
            var Appointment = AppointmentDto.GetAppointment(ID);
            ucPersonInfo1.SetProperties(Appointment.Patient);
            if(Appointment.Payment!=null)
                ucPaymentInfo1.SetProperties(Appointment.Payment.PaymentDate, Appointment.Payment.AmountPaid, Appointment.Payment.PaymentMethod);
            else
                ucPaymentInfo1.SetProperties(DateTime.Now,0,"Non");
            ucAppointmentInfo1.SetProperties(Appointment.AppointmentDate, Appointment.Appointmentstatus.Appointmentstatus);
            ucDoctorInfo1.SetProperties(Appointment.Doctor.FullName, Appointment.Doctor.Specialization.SpecializationName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
