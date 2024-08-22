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

namespace UI.Appointment
{
    /// <summary>
    /// Interaction logic for PagePatientAppointment.xaml
    /// </summary>
    public partial class PagePatientAppointment : Page
    {
      
        private int ID;
        enum enMode { Add, Update }
        private enMode _Mode;

        public Patient? Patient { get; set; }
        public PagePatientAppointment()
        {
            InitializeComponent();
            _Mode = enMode.Add;
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;

        }
        public PagePatientAppointment(int ID)
        {
            InitializeComponent();
            ucPersonSearch1.SearchResult += UcPersonSearch1_SearchResult;
            ucPersonSearch1.GetID(ID, PersonFolder.ucPersonSearch.Searchby.Person);
            _Mode = enMode.Update;
        }

        private void UcPersonSearch1_SearchResult(object? sender, PersonFolder.ucPersonSearch.InfoBackEventArges e)
        {


            if (_Mode == enMode.Add && e.TypeName == "Doc")
                if (MessageBox.Show("Can't Add this Doctor As Patient", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    return;




            if (_Mode == enMode.Add && e.TypeName == "Use")
                if (MessageBox.Show("Can't Add this Doctor As Patient", "Information"
                    , MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                    return;

            if (_Mode == enMode.Update && e.TypeName == "Doc")
                if (MessageBox.Show("Can't Update this information because it's belong to Doctor??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    return;


            if (_Mode == enMode.Update && e.TypeName == "Use")
                if (MessageBox.Show("Can't Update this information because it's belong to User??", "Information"
                    , MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.Cancel)
                    return;

            AddUpdatePerson1.SetProperties(e.FullName, e.Address, e.DateOfBirth, e.Email, e.Gender, e.Email2, e.Phone, e.Phone2);
            ID = e.ID;
            Patient = CrudExention.CreateDbContext().Set<Person>().OfType<Patient>().SingleOrDefault(p => p.ID == ID);
        }
    }
}

