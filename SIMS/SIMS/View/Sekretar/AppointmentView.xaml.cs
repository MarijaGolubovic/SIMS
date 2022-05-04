﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : Window
    {
        public static ObservableCollection<AppointmentsForSecretaryDTO> Appointments { get; set; }
        private static AppointmentController appoitmentController;

        public AppointmentView()
        {
            InitializeComponent();
            this.DataContext = this;
            appoitmentController = new AppointmentController();
            Appointments = new ObservableCollection<AppointmentsForSecretaryDTO>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateAppointmentView createAppointmentView = new CreateAppointmentView();
            createAppointmentView.Show();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Parse(datum.Text);
            Appointments.Clear();
            foreach (AppointmentsForSecretaryDTO a in appoitmentController.GetAppointmentsForSecretary(dateTime))
            {
                Appointments.Add(a);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void IZMENI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OTKAZI_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
