using Business;
using Data.Entities;
using System.Windows;

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for winAddUpdatePerson.xaml
    /// </summary>
    public partial class winAddUpdatePerson : Window
    {
        private int ID;
        private enum enMode { Add,Update}
        private enMode _Mode { get; set; }
        public winAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.Add;
            this.Title = "Add New Patient";
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            ucPersonSearch1.IsEnabled = true;
        }

        public winAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            this.Title = "Update Patient";
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            ucPersonSearch1.GetID(PersonID,ucPersonSearch.Searchby.Person);
        }


        private void UcPersonSearch1_SearchResult(object? sender, ucPersonSearch.InfoBackEventArges e)
        {
            if (_Mode == enMode.Add && e.TypeName == "Pat")
                if (MessageBox.Show("These Information about this Patient\n Aleardy Found no need to add", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();


            if (_Mode == enMode.Add && e.TypeName == "Doc")
                if (MessageBox.Show("Are You sure to add this Doctor as Patient??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();



            if (_Mode == enMode.Add && e.TypeName == "Use")
                if (MessageBox.Show("Are You sure to add this User as Patient??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();


            if (_Mode == enMode.Update && e.TypeName == "Doc")
                if (MessageBox.Show("Can't Update this information because it's belong to Doctor??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();



            if (_Mode == enMode.Update && e.TypeName == "Use")
                if (MessageBox.Show("Can't Update this information because it's belong to User??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();


            AddUpdatePerson1.SetProperties(e.FullName, e.Address, e.DateOfBirth, e.Email, e.Gender, e.Email2, e.Phone, e.Phone2);
            ID = e.ID;
        }


        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //1- create Person Object
            var context= CrudExention.CreateDbContext();

            if (_Mode == enMode.Add)
            {
                var Patient = CrudExention.CreatePatient(AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                    , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone, 
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);
                int ID=Patient.AddInDatabase((Patient) =>
                {
                    context.Persons.Add(Patient);
                    try
                    {
                        context.SaveChanges();
                        return Patient.ID;
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
                var OldPatient = context.Persons.SingleOrDefault(p => p.ID == this.ID);
                var NewPatient = CrudExention.CreatePatient(AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                    , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone,
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);

                if (OldPatient.UpdateInDatabase(NewPatient, (Old, New) =>
                {
                    Old.FullName = New.FullName;
                    Old.Gender = New.Gender;
                    Old.Phone = New.Phone;
                    Old.DateBirth = New.DateBirth;
                    Old.Email = New.Email;
                    Old.Phone2 = New.Phone2;
                    Old.Email2 = New.Email2;
                    Old.Address = New.Address;
                    try
                    {
                        context.SaveChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }

                }))
                {
                    Btn_Save.IsEnabled = false;
                }
                else
                    MessageBox.Show("Failed to Save", "FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


    }
}
