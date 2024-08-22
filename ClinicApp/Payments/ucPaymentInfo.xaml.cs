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

namespace UI.Payments
{
    /// <summary>
    /// Interaction logic for ucPaymentInfo.xaml
    /// </summary>
    public partial class ucPaymentInfo : UserControl
    {
        public ucPaymentInfo()
        {
            InitializeComponent();
        }
        public void SetProperties(DateTime time,double Amount,string? Method)
        {
            if(Amount!=0)
                Txt_AmountPaid.Text = Amount.ToString();
            else
                Txt_AmountPaid.Text = "0";
            if (time.CompareTo(DateTime.Today)==0)
                Txt_PaymentDate.Text = time.ToLongDateString();
            else
                Txt_PaymentDate.Text = "??";
            if(!string.IsNullOrWhiteSpace(Method))
                Txt_PaymentMethod.Text = Method;
        }
    }
}
