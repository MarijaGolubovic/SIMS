﻿using System.Windows;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for MainPatientWindow.xaml
    /// </summary>
    public partial class MainPatientWindow : Window
    {
        public MainPatientWindow()
        {
            InitializeComponent();
        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.Show();
        }

        private void AllAppointments(object sender, RoutedEventArgs e)
        {
            AllAppointments allAppointments = new AllAppointments();
            allAppointments.Show();
        }
    }
}
