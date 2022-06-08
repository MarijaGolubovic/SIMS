using System.Windows.Input;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for EditMedicine.xaml
    /// </summary>
    public partial class EditMedicine : Window
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
            /*List<string> ingrediets = new List<string>();
            ingrediets.Add("sastojak 1");
            ingrediets.Add("sastojak 2");
            ingrediets.Add("sastojak 3");

           Rooms.Add(new Model.Medicine("Paracetamol", ingrediets, Model.MedicineStatus.Valid, 2));
           Rooms.Add(new Model.Medicine("Brufen", ingrediets, Model.MedicineStatus.Invalid, 10));
           Rooms.Add(new Model.Medicine("Efedrin", ingrediets, Model.MedicineStatus.Invalid, 3));
           Rooms.Add(new Model.Medicine("Omnitus", ingrediets, Model.MedicineStatus.Valid, 6));
           Rooms.Add(new Model.Medicine("Tylol Hot", ingrediets, Model.MedicineStatus.Valid, 4));*/

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
                //  medicineStorage.Delete(selectedMedicine);
                // medicineStorage.Create(new Model.Medicine(nameBox.Text, ingredients, Model.MedicineStatus.OnHold, quantity));
                View.Menager.EditMedicine editMedicine = new EditMedicine();
                editMedicine.Show();
                this.Close();

            }
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
