﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SIMS.Model;

namespace SIMS.Pacijent
{
    /// <summary>
    /// Interaction logic for AllAppointments.xaml
    /// </summary>
    public partial class AllAppointments : Window
    {
        public static ObservableCollection<Model.Appointment> AppointmentsCollceciton { get; set; }
        public static List<Model.Appointment> AppointmentsCollceciton2 { get; set; }
        public static Appointment SelectedItem { get; set; }

        public AllAppointments()
        {
            InitializeComponent();
            this.DataContext = this;
            SelectedItem = null;

            Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();

            //ucitavam termine iz fajla
            List<Appointment> appointments = appointmentSerializer.fromCSV("appointments.txt");

            //inicijalizujem kolekciju
            AppointmentsCollceciton = new ObservableCollection<Appointment>();
            AppointmentsCollceciton2 = new List<Model.Appointment>();

            //ucitavam podatke u kolekciju
            foreach (Appointment item in appointments)
            {
                AppointmentsCollceciton.Add(item);
            }
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Appointment selectedRow = dataGridAllAppointments.SelectedItem as Appointment;
            if (selectedRow != null)
            {
                AppointmentsCollceciton.Remove(selectedRow);
                Serialization.Serializer<Appointment> appointmentSerializer = new Serialization.Serializer<Appointment>();
                appointmentSerializer.toCSV("appointments.txt", AllAppointments.AppointmentsCollceciton.ToList());
            }
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = dataGridAllAppointments.SelectedItem as Appointment;
            if (SelectedItem != null)
            {
                EditAppintment editAppintment = new EditAppintment();
                editAppintment.Show();
            }
        }
    }
}
