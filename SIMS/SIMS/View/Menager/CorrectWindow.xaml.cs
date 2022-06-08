using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for CorrectWindow.xaml
    /// </summary>
    public partial class CorrectWindow : Window
    {
        public static ObservableCollection<Model.Medicine> Rooms { get; set; }
        public static Model.Medicine selectedMedicine;
        public static Repository.MedicineStorage medicineService = new Repository.MedicineStorage();
        bool flag = false;

        public Repository.MedicineStorage medicineStorage = new Repository.MedicineStorage();
        public CorrectWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Serialization.Serializer<Model.Medicine> medicinceSerializer = new Serialization.Serializer<Model.Medicine>();
            //List<Model.Medicine> rooms = medicinceSerializer.fromCSV("medicine.txt");
            List<Model.Medicine> rooms = medicineService.FindInvalidMedicine();
            Rooms = new ObservableCollection<Model.Medicine>();
            foreach (Model.Medicine roomItem in rooms)
            {
                Rooms.Add(roomItem);
            }
            selectedMedicine = (Model.Medicine)dataGridMedicinesCorrect.SelectedItem;

        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            List<Model.Medicine> medicine = medicineStorage.GetAll();

            foreach (Model.Medicine medicineItem in medicine)
            {
                if (medicineItem.Name.Equals(selectedMedicine.Name))
                {
                    medicine.Remove(medicineItem);
                    Serialization.Serializer<Model.Medicine> medicinceSerializer = new Serialization.Serializer<Model.Medicine>();
                    medicinceSerializer.toCSV("medicine.txt", medicine);
                    break;
                }
            }


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
                View.Menager.EditMedicine editMedicine = new EditMedicine();
                editMedicine.Show();
                this.Close();

            }

        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGridMedicines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedMedicine = (Model.Medicine)dataGridMedicinesCorrect.SelectedItem;

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
            if (selectedMedicine.Name.Contains("Lekadol"))
            {
                commentBox.Text = "U naziv dodati extra";
            }
            else if (selectedMedicine.Name.Contains("Kafetin"))
            {
                commentBox.Text = "Dodati sastojakXXX";
            }
            else
            {
                commentBox.Text = "Dodati sastojakYYY";
            }


            nameBox.Text = selectedMedicine.Name;
            quantityBox.Text = selectedMedicine.Quantity.ToString();
            igredientsBox.Text = igredients;
            flag = true;

        }
    }
}
