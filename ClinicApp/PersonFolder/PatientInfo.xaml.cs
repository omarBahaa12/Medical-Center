using Business;
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
using System.Windows.Shapes;

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        public enum enPatientOrNot { Patient,Doctor,User}
        public enPatientOrNot _enMode { get; private set; }
        public int ID { get; private set; }

        public PatientInfo(int ID,enPatientOrNot enPatient)
        {
            InitializeComponent();
            this._enMode = enPatient;
            this.ID = ID;               
        }


        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (_enMode)
            {
                case enPatientOrNot.Patient:

                    ucDoctorInfo1.Visibility = Visibility.Collapsed;
                    ucUserInfo1.Visibility = Visibility.Collapsed;
                    var patient = PatientDto.GetPerson(ID);

                    ucPersonInfo1.SetProperties(patient);

                    ucTabControlView1.SetDataInDataView(AppointmentDto.GetAppointmentDtosByPersonID(ID)
               , MedicalRecordsDto.GetMedicalRecordsDtosByPeronID(ID), PaymentDto.GetPaymentDtosByPersonID(ID));

                    break;

                case enPatientOrNot.Doctor:
                    ucDoctorInfo1.Visibility = Visibility.Visible;
                    ucUserInfo1.Visibility = Visibility.Collapsed;


                    var Doctor = DoctorDto.GetDoctorbyID(ID);

                    ucPersonInfo1.SetProperties(Doctor);

                    ucDoctorInfo1.SetProperties(Doctor.FullName, Doctor.Specialization.SpecializationName);

                    ucTabControlView1.SetDataInDataView(AppointmentDto.GetAppointmentDtosByPersonID(ID)
               , MedicalRecordsDto.GetMedicalRecordsDtosByPeronID(ID), PaymentDto.GetPaymentDtosByPersonID(ID));

                    break;

                case enPatientOrNot.User:
                    ucDoctorInfo1.Visibility = Visibility.Collapsed;
                    ucUserInfo1.Visibility = Visibility.Visible;

                    var User = UserDto.GetUserDtos(ID);

                    ucPersonInfo1.SetProperties(User);

                    ucUserInfo1.SetProperties(User.UserName, User.Password);

                    ucTabControlView1.SetDataInDataView(AppointmentDto.GetAppointmentDtosByPersonID(ID)
               , MedicalRecordsDto.GetMedicalRecordsDtosByPeronID(ID), PaymentDto.GetPaymentDtosByPersonID(ID));

                    break;
            }
        }
    }
}
