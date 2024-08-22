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
    /// Interaction logic for ucUpdateAppointmentStatus.xaml
    /// </summary>
    public partial class ucUpdateAppointmentStatus : UserControl
    {
        public enum UpdateorNot { Update,NotUpdate}

        public ucUpdateAppointmentStatus()
        {
            InitializeComponent();
        }

        public void SetProperties(int ID,UpdateorNot updateor)
        {
            AppointmentDto appointmentDto = AppointmentDto.GetAppointmentDto(ID);
            switch (updateor)
            {
                case UpdateorNot.Update:
                    Cb_Status.IsEnabled = true;
                    break;
                case UpdateorNot.NotUpdate:
                    Cb_Status.IsEnabled = false;
                    break;
            }
            Txt_AppointmentDate.Text = appointmentDto.AppointmentDate.ToLongDateString();
            Txt_AppointmentID.Text = appointmentDto.AppointmentID.ToString();
            Txt_DoctorName.Text = appointmentDto.DoctorName;
            Txt_PatientName.Text = appointmentDto.PatientName;
            Txt_UserName.Text = appointmentDto.UserName;
            Txt_Resrvation.Text = appointmentDto.Resrvation;
            Cb_Status.ItemsSource = CrudExention.GetAppointmentStatus();
            Cb_Status.SelectedIndex = appointmentDto.StatusID - 1;
        }
    }
}
