using Business;
using Business.DTOs;
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
using UI.Appointment;
using UI.PersonFolder;

namespace UI.Payments
{
    /// <summary>
    /// Interaction logic for AddorUpdatePayment.xaml
    /// </summary>
    public partial class AddorUpdatePayment : Window
    {
        public enum Mode { Add,Update}

        public int PaymentID { get; private set; }
        public Mode enMode { get; private set; }
        public int AppointmentID { get; private set; }
        public double AmountPaid { get; private set; }
        public string PaidMethod { get; private set; }
        public DateTime? AppointmentDate { get; private set; }
        public AddorUpdatePayment()
        {
            InitializeComponent();
            enMode = Mode.Add;
            ucPersonSearch1.AppointmentInfo += UcPersonSearch1_AppointmentInfo;
            ucPersonSearch1.enSearchby = ucPersonSearch.Searchby.Appointment;
            ucAddPayment1.ReturnPaymentDetails += UcAddPayment1_ReturnPaymentDetails;
            
        }

        public AddorUpdatePayment(int ID)
        {
            InitializeComponent();
            PaymentID = ID;
            enMode = Mode.Update;
            var payment = PaymentDto.GetPaymentDto(ID);
            ucPersonSearch1.AppointmentInfo += UcPersonSearch1_AppointmentInfo;
            ucAddPayment1.ReturnPaymentDetails += UcAddPayment1_ReturnPaymentDetails;
            ucPersonSearch1.GetID(payment.AppointmentID, ucPersonSearch.Searchby.Appointment);
            ucAddPayment1.SetPerperties(payment.AmountPaid, payment.PaymentMethod, payment.PaymentDate);
        }

        private void UcAddPayment1_ReturnPaymentDetails(object? sender, ucAddPayment.PaymentDetailsEventArge e)
        {
            AmountPaid = e.AmountPaid;
            PaidMethod = e.PaymentMethod;
            AppointmentDate = e.PaymentDate;
        }

        private void UcPersonSearch1_AppointmentInfo(object? sender, PersonFolder.ucPersonSearch.AppointmentInfoBack e)
        {
            ucUpdateAppointmentStatus1.SetProperties(e.AppointmentID, ucUpdateAppointmentStatus.UpdateorNot.NotUpdate);
            AppointmentID = e.AppointmentID;
        }

        private bool Checking()
        {
            if (AppointmentID == default &&
                string.IsNullOrWhiteSpace(PaidMethod) &&
                AmountPaid == default &&
                AppointmentDate is null)
                return false;
            return true;
                
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if(Checking())
            {
                if (enMode == Mode.Add)
                {
                    var payment = CrudExention.CreatePayment(AppointmentID, AppointmentDate.Value,
                        AmountPaid, PaidMethod);
                    if (payment.AddInDatabase((p) =>
                    {
                        var context = CrudExention.CreateDbContext();
                        context.Payments.Add(p);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Saved Successfully", "Done", MessageBoxButton.OK, MessageBoxImage.Information);
                            return 1;
                        }
                        catch
                        {
                            MessageBox.Show("Failed To save", "Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
                            return 0;
                        }
                    }) == 1)
                        this.Close();
                }
                else
                {
                    using (var context=CrudExention.CreateDbContext())

                    {
                        var NewPayment = CrudExention.CreatePayment(AppointmentID, AppointmentDate!.Value, AmountPaid, PaidMethod);
                        var OldPayment = context.Payments.SingleOrDefault(p => p.ID == PaymentID);
                        if (OldPayment.UpdateInDatabase(NewPayment, (Old, New) =>
                        {
                            Old.AmountPaid = New.AmountPaid;
                            Old.PaymentDate = New.PaymentDate;
                            Old.PaymentMethod = New.PaymentMethod;
                            try
                            {
                                context.SaveChanges();
                                MessageBox.Show("Save Succssfully", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                                return true;

                            }
                            catch
                            {
                                MessageBox.Show("Failed To Save", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }))
                            this.Close();
                    }
                }
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
