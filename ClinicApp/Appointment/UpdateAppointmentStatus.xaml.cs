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
using System.Windows.Shapes;

namespace UI.Appointment
{
    /// <summary>
    /// Interaction logic for UpdateAppointmentStatus.xaml
    /// </summary>
    public partial class UpdateAppointmentStatus : Window
    {
        public UpdateAppointmentStatus(int ID)
        {
            InitializeComponent();
            ucUpdateAppointmentStatus1.SetProperties(ID, ucUpdateAppointmentStatus.UpdateorNot.Update);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
