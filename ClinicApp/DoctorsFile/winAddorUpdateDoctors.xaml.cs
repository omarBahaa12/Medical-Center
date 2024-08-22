using Business;
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
using UI.PersonFolder;

namespace UI.Doctors
{
    /// <summary>
    /// Interaction logic for winAddorUpdateDoctors.xaml
    /// </summary>
    public partial class winAddorUpdateDoctors : Window
    {
        private Doctor? doctor;

        private enum enMode :byte{Add,Update }
        private enMode Mode { get; set; }
        public int ID { get; private set; }

        public winAddorUpdateDoctors()
        {
            InitializeComponent();
            Mode = enMode.Add;
            this.Title = "Add Doctor";
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            ucPersonSearch1.IsEnabled = true;
           
        }

        public winAddorUpdateDoctors(int DoctorID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            this.Title = "Update Doctor";
            ucPersonSearch1.IsEnabled = true;
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            ucPersonSearch1.GetID(DoctorID,ucPersonSearch.Searchby.Person);
        }

        private void UcPersonSearch1_SearchResult(object? sender, ucPersonSearch.InfoBackEventArges e)
        {

            if(Mode==enMode.Add && e.TypeName=="Doc")
                if (MessageBox.Show("These Information about this Doctor\n Aleardy Found no need to add", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();


            if(Mode==enMode.Add&&e.TypeName=="Pat")
                if (MessageBox.Show("Are You sure to add this Patient as Doctor??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();



            if (Mode == enMode.Add && e.TypeName == "Use")
                if (MessageBox.Show("Are You sure to add this User as Doctor??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();


            if (Mode == enMode.Update && e.TypeName == "Pat")
                if (MessageBox.Show("Can't Update this information because it's belong to Patient??", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();



            if (Mode == enMode.Update && e.TypeName == "Use")
                if (MessageBox.Show("Can't Update this information because it's belong to User??", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();


            AddUpdatePerson1.SetProperties(e.FullName, e.Address, e.DateOfBirth, e.Email, e.Gender, e.Email2, e.Phone,e.Phone2);
            this.ID = e.ID;
            if (e.TypeName == "Doc")
            {
                doctor = CrudExention.CreateDbContext().Set<Person>().OfType<Doctor>().SingleOrDefault(d => d.ID == e.ID);
                ucDoctorSpecialization1.SetProperties(doctor.SpecializationId, e.ID);
            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var context = CrudExention.CreateDbContext();
            if (Mode==enMode.Add)
            {

                var Doctor = CrudExention.CreateDoctor(ucDoctorSpecialization1.SpecializationID,
                    AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone, 
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);


                int ID=Doctor.AddInDatabase((Doctor) =>
                {
                    context.Persons.Add(Doctor);
                    try
                    {
                        context.SaveChanges();
                        return Doctor.ID;
                    }
                    catch
                    {
                        return 0;
                    }
                });
                if (ID != 0)
                    Btn_Save.IsEnabled = false;
                else
                    MessageBox.Show("Failed to Save", "FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {

                var NewDoctor = CrudExention.CreateDoctor(ucDoctorSpecialization1.SpecializationID,
                    AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone,
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);


                if(doctor.UpdateInDatabase(NewDoctor,(Old,New) =>
                {
                    Old.FullName = New.FullName;
                    Old.Gender = New.Gender;
                    Old.Phone = New.Phone;
                    Old.DateBirth = New.DateBirth;
                    Old.Email = New.Email;
                    Old.Phone2 = New.Phone2;
                    Old.Email2 = New.Email2;
                    Old.Address = New.Address;
                    Old.SpecializationId = New.SpecializationId;
                    
                    try
                    {
                        context.Update(Old);
                        context.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }))
                    Btn_Save.IsEnabled = false;
                else
                    MessageBox.Show("Failed to Save", "FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
