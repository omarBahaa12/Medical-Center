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
using static UI.Users.ucAddUpdateUser;
using UI.PersonFolder;
using Business;
using Data.Entities;
using Microsoft.VisualBasic.ApplicationServices;
using static UI.Appointment.SelectAppointment;
using static UI.DoctorsFile.DoctorBySpecialization;
using Business.DTOs;

namespace UI.Appointment
{
    /// <summary>
    /// Interaction logic for winAddOrUpdateAppointment.xaml
    /// </summary>
    public partial class winAddOrUpdateAppointment : Window
    {
        private int ID;

        public Data.Entities.Appointment OldAppointment { get; private set; }

        enum enMode { Add,Update}
        private enMode _Mode;
        enum enStep { One,Two }
        private enStep _Step;
        private PagePatientAppointment patientAppointment;
        private PageSelectAppointment selectAppointment;
        private int PatientID;
        public winAddOrUpdateAppointment()
        {
            InitializeComponent();
            _Mode = enMode.Add;
            _Step = enStep.One;
            Frame.Content = patientAppointment = new PagePatientAppointment();

        }
        public winAddOrUpdateAppointment(int ID)
        {
            InitializeComponent();           
            _Mode = enMode.Update;
            _Step = enStep.One;
            this.ID = ID;
            OldAppointment = AppointmentDto.GetAppointment(ID);
            Frame.Content = patientAppointment = new PagePatientAppointment(OldAppointment.PatientID);
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (_Step == enStep.One)
            {
                if (patientAppointment.Patient is null)
                    if (MessageBox.Show("You Entered Wrong Patient", "Warning", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
                        this.Close();
                    else
                    { }

                else
                {
                    PatientID = patientAppointment.Patient.ID;
                    _Step = enStep.Two;
                    if (_Mode == enMode.Add)
                        Frame.Content = selectAppointment = new PageSelectAppointment();
                    else
                        Frame.Content = selectAppointment = new PageSelectAppointment(OldAppointment.DoctorID, OldAppointment.AppointmentDate);
                    Btn_Save.Content = "Save";
                    return;
                }
            }

            if(_Step==enStep.Two)
            {
                if (_Mode == enMode.Add)
                {
                    var Doctor = DoctorDto.GetDoctorbyName(selectAppointment.DoctorName);
                    if (Doctor is not null)
                    {
                        var Appointment = CrudExention.CreateAppointment(PatientID, Doctor.ID, 1, 1, selectAppointment.AppointmentDate);
                        if (Appointment.AddInDatabase(d =>
                        {
                            var context = CrudExention.CreateDbContext();
                            context.Appointments.Add(d);
                            return context.SaveChanges();

                        }) == 1)
                            if (MessageBox.Show("Saved Successfully", "Succesed", MessageBoxButton.OK, MessageBoxImage.Information)
                                == MessageBoxResult.OK)
                                this.Close();
                            else { }
                        else
                        {
                            if (MessageBox.Show("Failed to Save Try Again", "Failed", MessageBoxButton.OK, MessageBoxImage.Error)
                                == MessageBoxResult.OK)
                                this.Close();
                        }

                    }
                }
                else
                {
                    var Doctor = DoctorDto.GetDoctorbyName(selectAppointment.DoctorName);
                    if (Doctor is not null)
                    {
                        var context = CrudExention.CreateDbContext();
                        var NewAppointment = CrudExention.CreateAppointment(PatientID, Doctor.ID, 3, 1, selectAppointment.AppointmentDate);
                        if(OldAppointment.UpdateInDatabase(NewAppointment, (Old, New) =>
                        {
                            Old.PatientID = New.PatientID;
                            Old.UserID = New.UserID;
                            Old.AppointmentDate = New.AppointmentDate;
                            Old.DoctorID = New.DoctorID;
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
                            if (MessageBox.Show("Saved Successfully", "Succesed", MessageBoxButton.OK, MessageBoxImage.Information)
                                 == MessageBoxResult.OK)
                                    this.Close(); else { }
                        else
                        {
                            if (MessageBox.Show("Failed to Save Try Again", "Failed", MessageBoxButton.OK, MessageBoxImage.Error)
                                == MessageBoxResult.OK)
                                this.Close();
                        }
                    }
                }
            }
            
        }
    }
}
