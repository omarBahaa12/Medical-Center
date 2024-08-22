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

namespace UI.Users
{
    /// <summary>
    /// Interaction logic for ucAddUpdateUser.xaml
    /// </summary>
    public partial class ucAddUpdateUser : UserControl
    {
        public enum enMode { Add,Update}
        private enMode Mode { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ucAddUpdateUser()
        {
            InitializeComponent();            
        }

        internal void SetProperties(string? userName, string? password, int iD)
        {
            TxtB_Password.Text = password;
            TxtB_UserID.Text = iD.ToString();
            TxtB_UserName.Text = userName;
        }

        private void TxtB_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserName = TxtB_UserName.Text;
        }

        private void TxtB_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password = TxtB_Password.Text;
        }
    }
}
