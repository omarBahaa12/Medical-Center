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
    /// Interaction logic for ucAddPayment.xaml
    /// </summary>
    public partial class ucAddPayment : UserControl
    {
        public class PaymentDetailsEventArge:RoutedEventArgs
        {
            public PaymentDetailsEventArge(string paymentMethod, double amountPaid, DateTime? paymentDate)
            {
                PaymentMethod = paymentMethod;
                AmountPaid = amountPaid;
                if(paymentDate.HasValue)
                    PaymentDate = paymentDate.Value;
                else
                {
                    PaymentDate = DateTime.Now;
                }
            }

            public string PaymentMethod { get; set; }
            public double AmountPaid    { get; set; }
            public DateTime? PaymentDate { get; set; }



        }

        public event EventHandler<PaymentDetailsEventArge> ReturnPaymentDetails;

        protected virtual void Result(PaymentDetailsEventArge eventArge)
        {
            ReturnPaymentDetails?.Invoke(this,eventArge);
        }

        public ucAddPayment()
        {
            InitializeComponent();
            DatePayment.SelectedDate = DateTime.Now;
        }

        private bool check()
        {
            return Txtb_AmountPaid.Text == "" ? false : 
                (Txtb_PaymentMethod.Text == "" ? false : 
                (DatePayment.SelectedDate == DateTime.Now ? 
                true : true));
        }

        private void Txtb_PaymentMethod_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(check())
            {
                double.TryParse(Txtb_AmountPaid.Text, out double AmountPaid);
                Result(new PaymentDetailsEventArge(Txtb_PaymentMethod.Text,AmountPaid,DatePayment.SelectedDate));
            }
        }

        private void Txtb_AmountPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (check())
            {
                double.TryParse(Txtb_AmountPaid.Text, out double AmountPaid);
                Result(new PaymentDetailsEventArge(Txtb_PaymentMethod.Text, AmountPaid, DatePayment.SelectedDate));
            }
        }

        private void DatePayment_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (check())
            {
                double.TryParse(Txtb_AmountPaid.Text, out double AmountPaid);
                Result(new PaymentDetailsEventArge(Txtb_PaymentMethod.Text, AmountPaid, DatePayment.SelectedDate));
            }
        }

        internal void SetPerperties(double amountPaid, string? paymentMethod, DateTime paymentDate)
        {
            Txtb_AmountPaid.Text = amountPaid.ToString();
            Txtb_PaymentMethod.Text = paymentMethod;
            DatePayment.SelectedDate = paymentDate;
        }
    }
}
