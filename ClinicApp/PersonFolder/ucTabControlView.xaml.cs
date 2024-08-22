using Business.DTOs;
using Data.Entities;
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

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for ucTabControlView.xaml
    /// </summary>
    public partial class ucTabControlView : UserControl
    {
        public ucTabControlView()
        {
            InitializeComponent();
        }
        public void SetDataInDataView(List<AppointmentDto> Appointemnt, List<MedicalRecordsDto> medicalRecords, List<PaymentDto> paymentDto)
        {
            if (paymentDto is null || paymentDto.Count==0)
            {
                TiPayments.Visibility = Visibility.Hidden;
            }
            D_Appointments.ItemsSource = Appointemnt;
            D_MedicalRecords.ItemsSource = medicalRecords;
            D_Payment.ItemsSource = paymentDto;
        }
        
    }
}
