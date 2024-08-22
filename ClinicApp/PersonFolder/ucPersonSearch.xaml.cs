using Business;
using Business.DTOs;
using Data.Entities;
using System.Windows;
using System.Windows.Controls;

namespace UI.PersonFolder
{
    /// <summary>
    /// Interaction logic for ucPersonSearch.xaml
    /// </summary>
    public partial class ucPersonSearch : UserControl
    {
        private int ID;
        private string FullName;

        public class InfoBackEventArges : RoutedEventArgs
        {
            public int ID { get; private set; }
            public string FullName { get; private set; }
            public string Address { get; private set; }
            public bool Gender { get; private set; }
            public string Email { get; private set; }
            public string? Email2 { get; private set; }
            public DateTime DateOfBirth { get; private set; }
            public string Phone { get; private set; }
            public string? Phone2 { get; private set; }
            public string TypeName { get; set; } = null!;

            public InfoBackEventArges(int personId, string fullname, string address, bool gender,
                string email, DateTime dateofbirth, string phone, string TypeName,string? phone2 = null,
                string? email2 = null)
            {
                ID = personId;
                FullName = fullname;
                Address = address;
                Gender = gender;
                Email = email;
                DateOfBirth = dateofbirth;
                this.TypeName = TypeName;
                Phone = phone;
                if (!string.IsNullOrWhiteSpace(phone2))
                    Phone2 = phone2;
                if (!string.IsNullOrWhiteSpace(email2))
                    Email2 = email2;
            }

        }

        public event EventHandler<InfoBackEventArges> SearchResult;
        protected virtual void InfoResult(InfoBackEventArges e)
        {
            SearchResult?.Invoke(this, e);
        }


        public class AppointmentInfoBack:RoutedEventArgs
        {
            public AppointmentInfoBack(int appointmentID)
            {
                AppointmentID = appointmentID;
            }

            public int AppointmentID { get; set; }

        }

        public event EventHandler<AppointmentInfoBack> AppointmentInfo;

        protected virtual void AppointmentinfoBack(AppointmentInfoBack e)
        {
            AppointmentInfo?.Invoke(this, e);
        }
        
        public enum Searchby { Person,Appointment}
        public Searchby enSearchby;
        private enum enSearch { PersonID, FullName};
        private enSearch search { get; set; }
        public ucPersonSearch()
        {
            InitializeComponent();
            Cbox_SearchBy.SelectedIndex = 0;
        }

        private void Cbox_SearchBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Cbox_SearchBy.SelectedIndex)
            {
                case 0:
                    search = enSearch.PersonID;
                    break;
                case 1:
                    search = enSearch.FullName;
                    break;

            }
        }

        private TSource Search<TSource>(Func<TSource> func)
        {
            try
            {
                var patient = func.Invoke();
                
                return patient;
            }
            catch
            {
                return default;
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            if (enSearchby == Searchby.Person)
            {
                if (search == enSearch.PersonID)
                {
                    ReturnInfoToMother(Search(() =>
                   {
                       return CrudExention.CreateDbContext().Persons.SingleOrDefault(p => p.ID == ID);
                   }
                   ));
                }

                if (search == enSearch.FullName)
                {
                    ReturnInfoToMother(Search(() =>
                    {
                        return CrudExention.CreateDbContext().Persons.FirstOrDefault(p => p.FullName!.Substring(0, FullName.Length) == FullName);
                    }
                   ));
                }
            }

            else
            {
                ReturnInfoToMother(Search(() =>
                {
                    return AppointmentDto.GetAppointmentDto(ID);
                }
                  ));
            }

        }

        private void ReturnInfoToMother<TSource>(TSource? source)
        {
            if (source is null)
            {
                MessageBox.Show("Not Found", "Information", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }


            if (enSearchby == Searchby.Person)
            {


                var person = source as Person;
                if (person is not null)
                {
                    var Info = new InfoBackEventArges(person.ID, person.FullName!, person.Address!, person.Gender,
                        person.Email!, person.DateBirth, person.Phone!, person.TypeName, person.Phone2, person.Email2);
                    InfoResult(Info);
                    return;
                }

            }


            else
            {
                var appointment = source as AppointmentDto;
                if(appointment is not null)
                {
                    AppointmentinfoBack(new AppointmentInfoBack(appointment.AppointmentID));
                    return;
                }
            }


            MessageBox.Show("Not Found", "Information", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        internal void GetID(int personID,Searchby search)
        {
            switch (search)
            {
                case Searchby.Person:
                    enSearchby = Searchby.Person;
                    break;
                case Searchby.Appointment:
                    enSearchby = Searchby.Appointment;
                    break;
            }
            ID = personID;
            Tb_Search.Text = ID.ToString();
        }

        private void Tb_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (enSearchby == Searchby.Person)
            {
                if (search == enSearch.PersonID)
                {
                    if (int.TryParse(Tb_Search.Text, out int Id))
                        ID = Id;
                    else
                        Tb_Search.Text = "";
                }
                else
                {
                    FullName = Tb_Search.Text;
                }
            }
            else
            {
                if (int.TryParse(Tb_Search.Text, out int Id))
                    ID = Id;
                else
                    Tb_Search.Text = "";
            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (enSearchby)
            {
                case Searchby.Person:
                    Cbox_SearchBy.Items.RemoveAt(2);
                    break;
                case Searchby.Appointment:
                    Cbox_SearchBy.Items.RemoveAt(0);
                    Cbox_SearchBy.Items.RemoveAt(0);

                    break;
            }
        }
    }
}
