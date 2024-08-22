using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace UI.Doctors
{
    /// <summary>
    /// Interaction logic for ucDoctorSpecialization.xaml
    /// </summary>
    public partial class ucDoctorSpecialization : UserControl
    {
        public int SpecializationID;
        public ucDoctorSpecialization()
        {
            InitializeComponent();
            CbDoctorSpecialization.ItemsSource = CrudExention.GetSpecializations();
        }

        internal void SetProperties(int? specializationId,int ID)
        {
            if (specializationId.HasValue)
                CbDoctorSpecialization.SelectedIndex = specializationId.Value - 1;
            else
                CbDoctorSpecialization.SelectedIndex = 4;
            Txtb_DoctorID.Text = ID.ToString();

        }

        private void CbDoctorSpecialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpecializationID = CbDoctorSpecialization.SelectedIndex+1;
        }
    }
}
