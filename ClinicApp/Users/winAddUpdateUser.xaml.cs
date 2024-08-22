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
using UI;
using UI.Doctors;
using UI.PersonFolder;

namespace UI.Users
{
    /// <summary>
    /// Interaction logic for winAddUpdateUser.xaml
    /// </summary>
    public partial class winAddUpdateUser : Window
    {
        private User? user;
        private enum enMode : byte { Add, Update }
        private enMode Mode { get; set; }
        public int ID { get; private set; }

        public winAddUpdateUser()
        {
            InitializeComponent();
            ucPersonSearch1.IsEnabled = true;
            Mode = enMode.Add;
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            this.Title = "Add User";

        }

        public winAddUpdateUser(int ID)
        {
            InitializeComponent();
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            Mode = enMode.Update;
            this.Title = "Update User";
            ucPersonSearch1.IsEnabled = true;
            ucPersonSearch1.GetID(ID,ucPersonSearch.Searchby.Person);
        }

        private void UcPersonSearch1_SearchResult(object? sender, ucPersonSearch.InfoBackEventArges e)
        {
            if (Mode == enMode.Add && e.TypeName == "Use")
                if (MessageBox.Show("These Information about this User\n Aleardy Found no need to add", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();


            if (Mode == enMode.Add && e.TypeName == "Pat")
                if (MessageBox.Show("Are You sure to add this Patient as User??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();



            if (Mode == enMode.Add && e.TypeName == "Doc")
                if (MessageBox.Show("Are You sure to add this Doctor as User??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    this.Close();



            if (Mode == enMode.Update && e.TypeName == "Pat")
                if (MessageBox.Show("Can't Update this information because it's belong to Patient??", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();



            if (Mode == enMode.Update && e.TypeName == "Doc")
                if (MessageBox.Show("Can't Update this information because it's belong to Doctor??", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    this.Close();


            AddUpdatePerson1.SetProperties(e.FullName, e.Address, e.DateOfBirth, e.Email, e.Gender, e.Email2, e.Phone, e.Phone2);
            this.ID = e.ID;
            if (e.TypeName == "Use")
            {
                user = CrudExention.CreateDbContext().Set<Person>().OfType<User>().SingleOrDefault(u => u.ID == e.ID);
                ucAddUpdateUser1.SetProperties(user.UserName,user.Password,e.ID);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var context = CrudExention.CreateDbContext();


            if (Mode == enMode.Add)
            {

                var user = CrudExention.CreateUser(ucAddUpdateUser1.UserName,ucAddUpdateUser1.Password,
                    AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone,
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);


                int ID = user.AddInDatabase((u) =>
                {
                    context.Persons.Add(u);
                    try
                    {
                        context.SaveChanges();
                        return u.ID;
                    }
                    catch
                    {
                        return 0;
                    }
                });
                if (ID != 0)
                    Save.IsEnabled = false;
                else
                    MessageBox.Show("Failed to Save", "FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                var NewUser = CrudExention.CreateUser(ucAddUpdateUser1.UserName, ucAddUpdateUser1.Password,
                    AddUpdatePerson1.Fullname, AddUpdatePerson1.date, AddUpdatePerson1.Gender
                , AddUpdatePerson1.Address, AddUpdatePerson1.Email, AddUpdatePerson1.Phone,
                    AddUpdatePerson1.Email2, AddUpdatePerson1.Phone2);


                if( user.UpdateInDatabase(NewUser,(Old,New) =>
                {
                    Old.FullName = New.FullName;
                    Old.Gender = New.Gender;
                    Old.Phone = New.Phone;
                    Old.DateBirth = New.DateBirth;
                    Old.Email = New.Email;
                    Old.Phone2 = New.Phone2;
                    Old.Email2 = New.Email2;
                    Old.Address = New.Address;
                    Old.UserName = New.UserName;
                    Old.Password = New.Password;
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

                    Save.IsEnabled = false;
                else
                    MessageBox.Show("Failed to Save", "FAILED", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
