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
    /// Interaction logic for AddUpdatePerson.xaml
    /// </summary>
    public partial class AddUpdatePerson : UserControl
    {
        public string Fullname=null!;
        public bool Gender;
        public string Address = null!;
        public DateTime date;
        public string Email = null!;
        public string Phone = null!;
        public string Email2 = null!;
        public string Phone2 = null!;

        public AddUpdatePerson()
        {
            InitializeComponent();
        }

        private void ReviewText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            foreach (var cr in e.Text)
            {
                if (!char.IsLetter(cr))
                {
                    e.Handled = true;
                    MessageBox.Show("Can't Enter Number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }

                break;
            }
        }

        private void ReviewNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var cr in e.Text)
            {
                if (char.IsLetter(cr))
                {
                    e.Handled = true;
                    MessageBox.Show("Can't Enter Character", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                break;
            }
        }

        private void Txtb_FullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Fullname = Txtb_FullName.Text;
        }

        private void Txtb_Address_TextChanged(object sender, TextChangedEventArgs e)
        {
            Address = Txtb_Address.Text;
        }

        private void Txtb_Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email = Txtb_Email.Text;
        }

        private void Txtb_PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            Phone = Txtb_PhoneNumber.Text;
        }

        private void Txtb_PhoneNumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Phone2 = Txtb_PhoneNumber2.Text;
        }

        private void Txtb_Email2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Email2 = Txtb_Email2.Text;
        }

        private void Comb_Gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Comb_Gender.SelectedIndex == 0)
                Gender = true;
            else
                Gender = false;
        }

        private void Date_DateofBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date_DateofBirth.SelectedDate != null)

                date = (DateTime)Date_DateofBirth.SelectedDate;
            else
                date = DateTime.Now;
        }

        internal void SetProperties(string fullName, string address, DateTime dateOfBirth, 
            string email, bool gender, string? email2, string phone, string? phone2)
        {
            Txtb_FullName.Text = fullName;
            Txtb_PhoneNumber.Text = phone;
            Txtb_PhoneNumber2.Text = phone2;
            Date_DateofBirth.SelectedDate = dateOfBirth;
            Txtb_Address.Text = address;
            Txtb_Email.Text = email;
            Txtb_Email2.Text = email2;
            if (gender)
                Comb_Gender.SelectedIndex = 0;
            else
                Comb_Gender.SelectedIndex = 1;
        }
    }
}
