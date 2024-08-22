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

namespace UI.DoctorsFile
{
    /// <summary>
    /// Interaction logic for DoctorBySpecialization.xaml
    /// </summary>
    public partial class DoctorBySpecialization : UserControl
    {
        public delegate void Doctor(string? DoctorName);
        public event Doctor GetDoctorName;
        public DoctorBySpecialization()
        {
            InitializeComponent();
            Comb_Specialization.ItemsSource = CrudExention.GetSpecializations();
        }

        private void Comb_Specialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Comb_Doctors.ItemsSource = CrudExention.GetDoctorsBySpecialization(Comb_Specialization.SelectedItem.ToString());
        }

        private void Comb_Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Comb_Doctors.SelectedValue!=null)
                GetDoctorName?.Invoke(Comb_Doctors.SelectedValue.ToString());
        }

        internal void SetDoctor(int doctorID)
        {
            var doctor = DoctorDto.GetDoctorbyID(doctorID);
            Comb_Specialization.SelectedIndex = doctor.SpecializationId-1;
            foreach (var item in Comb_Doctors.Items)
                if (item.ToString() == doctor.FullName)
                    Comb_Doctors.SelectedItem = item;
        }
    }
}
