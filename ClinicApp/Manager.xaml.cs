using UI.Doctors;
using UI.Users;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Business.DTOs;
using Data.Entities;
using Business;
using System.CodeDom;
using System.Reflection;
using UI.Appointment;
using static UI.PersonFolder.ManagementPesons;
using UI.Payments;

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for ManagementPatient.xaml
    /// </summary>
    public partial class ManagementPesons : UserControl
    {
        public enum enPatientorDoctors { Patients, Doctors, Users,Appointments,Payments,MedicalRecords }

        public enPatientorDoctors PatientorDoctors { get; set; }
        private static List<string> ListCombobox = new List<string> { "ID" };

        private int ID { get; set; }
        public ManagementPesons(enPatientorDoctors en)
        {
            InitializeComponent();
            PatientorDoctors = en;
        }

        private void Cmbox_FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Cmbox_FilterBy.SelectedIndex)
            {
                case 0:
                    Txtb_Filter.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Txtb_Filter.Visibility = Visibility.Visible;
                    break;
                case 2:
                    Txtb_Filter.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void AddOrUpdatePatient(int? ID)
        {
            winAddUpdatePerson win;
            if (ID.HasValue)
            {
                win = new winAddUpdatePerson(ID.Value);
            }
            else
            {
                win = new winAddUpdatePerson();
            }
            win.ShowDialog();

        }

        private void AddOrUpdateDoctor(int? ID)
        {
            winAddorUpdateDoctors win;
            if (ID.HasValue)
            {
                win = new winAddorUpdateDoctors(ID.Value);
            }
            else
            {
                win = new winAddorUpdateDoctors();
            }
            win.ShowDialog();

        }

        private void AddOrUpdateUser(int? ID)
        {
            winAddUpdateUser win;
            if (ID.HasValue)
            {
                win = new winAddUpdateUser(ID.Value);
            }
            else
            {
                win = new winAddUpdateUser();
            }
            win.ShowDialog();
        }

        private void AddOrUpdateAppointment(int? ID)
        {
            winAddOrUpdateAppointment win;
            if (ID.HasValue)
            {
                win = new winAddOrUpdateAppointment(ID.Value);
            }
            else
            {
                win = new winAddOrUpdateAppointment();
            }
            win.ShowDialog();
        }
        private void AddOrUpdatePayment(int? ID)
        {
            AddorUpdatePayment win;
            if (ID.HasValue)
            {
                win = new AddorUpdatePayment(ID.Value);
            }
            else
            {
                win = new AddorUpdatePayment();
            }
            win.ShowDialog();
        }
        private void AddOrUpdateMedicalRecord(int? ID)
        {
            winAddOrUpdateAppointment win;
            if (ID.HasValue)
            {
                win = new winAddOrUpdateAppointment(ID.Value);
            }
            else
            {
                win = new winAddOrUpdateAppointment();
            }
            win.ShowDialog();
        }

        private void MItem_Update_Click(object sender, RoutedEventArgs e)
        {
            switch (PatientorDoctors)
            {
                case enPatientorDoctors.Patients:
                    var Index1 = DG_Persons.SelectedItem as PatientDto;
                    AddOrUpdatePatient(Index1!.ID);
                    break;
                case enPatientorDoctors.Doctors:
                    var Index2 = DG_Persons.SelectedItem as DoctorDto;
                    AddOrUpdateDoctor(Index2!.ID);
                    break;
                case enPatientorDoctors.Users:
                    var Index3 = DG_Persons.SelectedItem as UserDto;
                    AddOrUpdateUser(Index3!.ID);
                    break;
                case enPatientorDoctors.Appointments:
                    var Index4 = DG_Persons.SelectedItem as AppointmentDto;
                    AddOrUpdateAppointment(Index4!.AppointmentID);
                    break;
                case enPatientorDoctors.Payments:
                    var Index5 = DG_Persons.SelectedItem as PaymentDto;
                    AddOrUpdatePayment(Index5!.ID);
                    break;
                case enPatientorDoctors.MedicalRecords:
                    var Index6 = DG_Persons.SelectedItem as MedicalRecordsDto;
                    AddOrUpdateMedicalRecord(Index6!.ID);
                    break;
            }

        }
        private void MItem_Delete_Click(object sender, RoutedEventArgs e)
        {
            var context = CrudExention.CreateDbContext();

            switch (PatientorDoctors)
            {
                case enPatientorDoctors.Patients:
                    var Index = DG_Persons.SelectedItem as PatientDto;
                    var person = context.Persons.SingleOrDefault(p => p.ID == Index!.ID);
                    if (person.DeleteInDatabase((p) =>
                    {
                        if (p is null)
                            return false;
                        context.Persons.Remove(p);
                        context.SaveChanges();
                        return true;
                    }
                    ))
                        MessageBox.Show("Done", "Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Failed", "Not Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;


                case enPatientorDoctors.Doctors:
                    var Index1 = DG_Persons.SelectedItem as DoctorDto;
                    var person1 = context.Persons.SingleOrDefault(p => p.ID == Index1!.ID);
                    if (person1.DeleteInDatabase((p) =>
                    {
                        if (p is null)
                            return false;
                        context.Persons.Remove(p);
                        context.SaveChanges();
                        return true;
                    }
                    ))
                        MessageBox.Show("Done", "Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Failed", "Not Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;


                case enPatientorDoctors.Users:
                    var Index2 = DG_Persons.SelectedItem as UserDto;
                    var person2 = context.Persons.SingleOrDefault(p => p.ID == Index2!.ID);
                    if (person2.DeleteInDatabase((p) =>
                    {
                        if (p is null)
                            return false;
                        context.Persons.Remove(p);
                        context.SaveChanges();
                        return true;
                    }
                     ))
                        MessageBox.Show("Done", "Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Failed", "Not Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;


                case enPatientorDoctors.Appointments:
                    var Index3 = DG_Persons.SelectedItem as AppointmentDto;
                    var person3 = context.Appointments.SingleOrDefault(p => p.ID == Index3!.AppointmentID);
                    if (person3.DeleteInDatabase((p) =>
                    {
                        if (p is null)
                            return false;
                        context.Appointments.Remove(p);
                        context.SaveChanges();
                        return true;
                    }
                     ))
                        MessageBox.Show("Done", "Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Failed", "Not Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;

                case enPatientorDoctors.Payments:
                    var Index4 = DG_Persons.SelectedItem as PaymentDto;
                    var person4 = context.Payments.SingleOrDefault(p => p.ID == Index4!.AppointmentID);
                    if (person4.DeleteInDatabase((p) =>
                    {
                        if (p is null)
                            return false;
                        context.Payments.Remove(p);
                        context.SaveChanges();
                        return true;
                    }
                     ))
                        MessageBox.Show("Done", "Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Failed", "Not Deleted successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            switch (PatientorDoctors)
            {
                case enPatientorDoctors.Patients:
                    AddOrUpdatePatient(null);
                    break;
                case enPatientorDoctors.Doctors:
                    AddOrUpdateDoctor(null);

                    break;
                case enPatientorDoctors.Users:
                    AddOrUpdateUser(null);

                    break;
                case enPatientorDoctors.Appointments:
                    AddOrUpdateAppointment(null);

                    break;
                case enPatientorDoctors.Payments:
                    AddOrUpdatePayment(null);

                    break;
                case enPatientorDoctors.MedicalRecords:
                    AddOrUpdateMedicalRecord(null);

                    break;
            }
        }

        private void LoadingData()
        {
            switch (PatientorDoctors)
            {
                case enPatientorDoctors.Patients:
                    SetListinDataView(PatientDto.GetPatientDtos());

                    break;
                case enPatientorDoctors.Doctors:
                    SetListinDataView(DoctorDto.GetDoctorDtos());
                    break;
                case enPatientorDoctors.Users:
                    SetListinDataView(UserDto.GetUserDtos());
                    break;
                case enPatientorDoctors.Appointments:
                    SetListinDataView(AppointmentDto.GetAppointmentDtos());
                    break;
                case enPatientorDoctors.Payments:
                    SetListinDataView(PaymentDto.GetPaymentDtos());                    
                    break;
                case enPatientorDoctors.MedicalRecords:
                    SetListinDataView(MedicalRecordsDto.GetMedicalRecordsDtos());
                    break;
            }
            Cmbox_FilterBy.ItemsSource = ListCombobox;
        }

        private void SetListinDataView(List<MedicalRecordsDto> medicalRecordsDtos)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = medicalRecordsDtos;
            if(DG_Persons.Columns.Count>=7)
            {
                DG_Persons.Columns.RemoveAt(6);
                DG_Persons.Columns.RemoveAt(6);
            }
        }

        private void SetListinDataView(List<PaymentDto> paymentDtos)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = paymentDtos;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ListCombobox.Exists(s => s == "PatientName"))
                ListCombobox.RemoveAt(1);
            ListCombobox.Insert(1, "FullName");
            MItem_UpdateStatus.Visibility = Visibility.Collapsed;
            
            if (PatientorDoctors == enPatientorDoctors.Appointments ||
                PatientorDoctors == enPatientorDoctors.Payments
                || PatientorDoctors == enPatientorDoctors.MedicalRecords)
            {
                if (ListCombobox.Exists(s => s == "FullName"))
                    ListCombobox.RemoveAt(1);
                ListCombobox.Insert(1, "PatientName");
                MItem_UpdateStatus.Visibility = Visibility.Collapsed;
            }
            LoadingData();
        }

        private void SetListinDataView(List<PatientDto> sources)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = sources;
        }

        private void SetListinDataView(List<DoctorDto> sources)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = sources;
        }

        private void SetListinDataView(List<UserDto> sources)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = sources;
        }

        private void SetListinDataView(List<AppointmentDto> sources)
        {
            DG_Persons.ColumnWidth = 130;
            DG_Persons.CanUserAddRows = false;
            DG_Persons.CanUserDeleteRows = false;
            DG_Persons.CanUserResizeColumns = false;
            DG_Persons.CanUserResizeRows = false;
            DG_Persons.ItemsSource = sources;
            if(DG_Persons.Columns.Count>6)
                DG_Persons.Columns.RemoveAt(7);
        }

        private void Btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadingData();
        }

        private void MItem_UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            var index = DG_Persons.SelectedItem as AppointmentDto;
            if (index != null)
            {
                var Appointmentinfo = new UpdateAppointmentStatus(index.AppointmentID);
                Appointmentinfo.ShowDialog();
            }
        }

        private void MItem_ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            switch (PatientorDoctors)
            {
                case enPatientorDoctors.Patients:
                    ShowPatientInfo();
                    break;
                case enPatientorDoctors.Doctors:
                    ShowDoctorInfo();
                    break;
                case enPatientorDoctors.Users:
                    ShowUserInfo();
                    break;
                case enPatientorDoctors.Appointments:
                    ShowAppointmentInfo();
                    break;
            }
        }

        private void ShowAppointmentInfo()
        {
            var index = DG_Persons.SelectedItem as AppointmentDto;
            if(index !=null)
            {
                var Appointmentinfo = new AppointmentInfo(index.AppointmentID);
                Appointmentinfo.ShowDialog();
            }
        }

        private void ShowUserInfo()
        {
            var index = DG_Persons.SelectedItem as UserDto;
            if (index != null)
            {
                var Appointmentinfo = new PatientInfo(index.ID,PatientInfo.enPatientOrNot.User);
                Appointmentinfo.ShowDialog();

            }
        }

        private void ShowDoctorInfo()
        {
            var index = DG_Persons.SelectedItem as DoctorDto;
            if (index != null)
            {
                var Appointmentinfo = new PatientInfo(index.ID,PatientInfo.enPatientOrNot.Doctor);
                Appointmentinfo.ShowDialog();
            }
        }

        private void ShowPatientInfo()
        {
            var index = DG_Persons.SelectedItem as PatientDto;
            if (index != null)
            {
                var Appointmentinfo = new PatientInfo(index.ID,PatientInfo.enPatientOrNot.Patient);
                Appointmentinfo.ShowDialog();
            }
        }

        private void Txtb_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(Txtb_Filter.Text,out int ID))
            {
                switch (PatientorDoctors)
                {
                    case enPatientorDoctors.Patients:
                        SetListinDataView (PatientDto.GetPatientDtos(ID));
                        break;
                    case enPatientorDoctors.Doctors:
                         SetListinDataView( DoctorDto.GetDoctorDtos(ID));
                        break;
                    case enPatientorDoctors.Users:
                        SetListinDataView(UserDto.GetUserDto(ID));
                        break;
                    case enPatientorDoctors.Appointments:
                        SetListinDataView(AppointmentDto.GetAppointmentDtos(ID));
                        break;
                    case enPatientorDoctors.Payments:
                        SetListinDataView(PaymentDto.GetPaymentDtos(ID));
                        break;
                    case enPatientorDoctors.MedicalRecords:
                        SetListinDataView(MedicalRecordsDto.GetMedicalRecordsDtos(ID));
                        break;
                }
            }


            else if(!int.TryParse(Txtb_Filter.Text, out int Id))
            {
                switch (PatientorDoctors)
                {
                    case enPatientorDoctors.Patients:
                        SetListinDataView( PatientDto.GetPatientDtos(Txtb_Filter.Text));
                        break;
                    case enPatientorDoctors.Doctors:
                        SetListinDataView(DoctorDto.GetDoctorDtos(Txtb_Filter.Text));
                        break;
                    case enPatientorDoctors.Users:
                        SetListinDataView(UserDto.GetUserDto(Txtb_Filter.Text));
                        break;
                    case enPatientorDoctors.Appointments:
                        SetListinDataView(AppointmentDto.GetAppointmentDtos(Txtb_Filter.Text));
                        break;

                    case enPatientorDoctors.Payments:
                        SetListinDataView(PaymentDto.GetPaymentDtos(Txtb_Filter.Text));
                        break;

                    case enPatientorDoctors.MedicalRecords:
                        SetListinDataView( MedicalRecordsDto.GetMedicalRecordsDtos(Txtb_Filter.Text));
                        break;
                }
            }


            if(Txtb_Filter.Text=="")
            {
                LoadingData();
            }
        }


    }
}
