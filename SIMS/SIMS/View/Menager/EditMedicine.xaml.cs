﻿using System.Windows.Input;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for EditMedicine.xaml
    /// </summary>
    public partial class EditMedicine : Page
    {
        public static ObservableCollection<Model.Medicine> Rooms { get; set; }
        public static Model.Medicine selectedMedicine;
        bool flag = false;

        public Repository.MedicineStorage medicineStorage = new Repository.MedicineStorage();
        public EditMedicine()
        {
            InitializeComponent();
            this.DataContext = this;
            Serialization.Serializer<Model.Medicine> medicinceSerializer = new Serialization.Serializer<Model.Medicine>();
            List<Model.Medicine> rooms = medicinceSerializer.fromCSV("medicine.txt");
            Rooms = new ObservableCollection<Model.Medicine>();
            
            foreach (Model.Medicine roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }
        }

        private void dataGridMedicines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedMedicine = (Model.Medicine)dataGridMedicines.SelectedItem;

            List<string> medecineIgredients = new List<string>();
            foreach (string item in selectedMedicine.Ingredients)
            {
                medecineIgredients.Add(item);
            }


            string igredients = "";

            for (int i = 1; i < medecineIgredients.Count; i++)
            {
                igredients = medecineIgredients[0];
                igredients += ",";
                igredients += medecineIgredients[i];

            }


            nameBox.Text = selectedMedicine.Name;
            quantityBox.Text = selectedMedicine.Quantity.ToString();
            igredientsBox.Text = igredients;
            flag = true;
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                int quantity = int.Parse(quantityBox.Text);
                List<String> ingredients = new List<String>();
                string[] tokens = igredientsBox.Text.Trim().Split(',');
                for (int i = 0; i < tokens.Length; i++)
                {
                    ingredients.Add(tokens[i]);
                }

                Model.Medicine newMedecine = new Model.Medicine(nameBox.Text, ingredients, Model.MedicineStatus.OnHold, quantity);


                medicineStorage.EditMedicine(selectedMedicine, newMedecine);
                
                feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(feedbackMessage);
                
            }
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }

       
    }
}
