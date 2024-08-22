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
    /// Interaction logic for ucDoctorInfo.xaml
    /// </summary>
    public partial class ucDoctorInfo : UserControl
    {
        public ucDoctorInfo()
        {
            InitializeComponent();
        }

        internal void SetProperties(string? fullName, string? specializationName)
        {
            Txt_DoctorName.Text = fullName;
            Txt_Specialization.Text = specializationName;
        }
    }
}
