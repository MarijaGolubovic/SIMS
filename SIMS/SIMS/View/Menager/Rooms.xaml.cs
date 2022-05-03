﻿using System;
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

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public Rooms()
        {
            InitializeComponent();
        }

        private void UpdateBack_Click_Moving(object sender, RoutedEventArgs e)
        {
            MovingWindow movingWindow = new MovingWindow();
            movingWindow.Show();
            this.Close();
        }

        private void Label_MouseDoubleClickEqupment(object sender, MouseButtonEventArgs e)
        {
            EqupmentPanel equpmentPanel = new EqupmentPanel();
            equpmentPanel.Owner = this;
            equpmentPanel.Show();
        }

        private void UpdateBack_Click_Back(object sender, RoutedEventArgs e)
        {
            MovingWindow movingWindow = new MovingWindow();
            movingWindow.Show();
            movingWindow.Close();
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Rooms_MouseDoubleClick_OK(object sender, MouseButtonEventArgs e)
        {
            RoomsPanel roomsPanel = new RoomsPanel();
            roomsPanel.Owner = this;
            roomsPanel.Show();
        }
    }
}