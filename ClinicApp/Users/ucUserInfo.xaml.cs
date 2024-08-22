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
    /// Interaction logic for ucUserInfo.xaml
    /// </summary>
    public partial class ucUserInfo : UserControl
    {
        public ucUserInfo()
        {
            InitializeComponent();
        }
        internal void SetProperties(string? Password,string? UserName)
        {
            Txt_Password.Password = Password;
            Txt_UserName.Text = UserName;
        }
    }
}
