using Business;
using Business.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using UI.PersonFolder;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ChangeTextLabel(object sender)
        {
            var Btn = (Button)sender;
            Txt_NamePage.Text = Btn.Content.ToString();
        }
        private void SetPanel(UserControl control)
        {
            Main_Pan.Children.Clear();
            Main_Pan.Children.Add(control);
        }
        private void Btn_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
        }

        private void Btn_Patient_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
            var ManagPerson = new ManagementPesons(ManagementPesons.enPatientorDoctors.Patients);
            SetPanel(ManagPerson);

        }

        private void Btn_Doctors_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);

            var ManagPerson = new ManagementPesons(ManagementPesons.enPatientorDoctors.Doctors);
            SetPanel(ManagPerson);
        }

        private void Btn_Users_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
            var ManagPerson=  new ManagementPesons(ManagementPesons.enPatientorDoctors.Users);
            SetPanel(ManagPerson);
        }

        private void Btn_Appointments_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
            var ManagPerson = new ManagementPesons(ManagementPesons.enPatientorDoctors.Appointments);
            SetPanel(ManagPerson);
        }

        private void Btn_Payment_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
            var ManagPerson = new ManagementPesons(ManagementPesons.enPatientorDoctors.Payments);
            SetPanel(ManagPerson);
        }

        private void Btn_MedicalRecords_Click(object sender, RoutedEventArgs e)
        {
            ChangeTextLabel(sender);
            var ManagPerson = new ManagementPesons(ManagementPesons.enPatientorDoctors.MedicalRecords);
            SetPanel(ManagPerson);
        }
    }
}
