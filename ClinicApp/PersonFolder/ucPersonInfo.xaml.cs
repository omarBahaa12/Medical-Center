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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for ucPersonInfo.xaml
    /// </summary>
    public partial class ucPersonInfo : UserControl
    {
        public ucPersonInfo()
        {
            InitializeComponent();
        }

      
        public void SetProperties(Person Person)
        {
            if (Person is not null)
            {
                TextB_FullName.Text = Person.FullName;
                TextB_Address.Text = Person.Address;
                TextB_DateofBirth.Text = Person.DateBirth.ToShortDateString();
                TextB_Email.Text = Person.Email;
                TextB_Phone.Text = Person.Phone;
                if (Person.Gender)
                    TextB_Gender.Text = "Male";
                else
                    TextB_Gender.Text = "Female";
            }
        }
    }
}
