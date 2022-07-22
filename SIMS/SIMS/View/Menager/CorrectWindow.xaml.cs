using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for CorrectWindow.xaml
    /// </summary>
    /// 
    public partial class CorrectWindow : Page
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
            buttonCORRECT.IsEnabled = false;
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
            // Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            Regex regex = new Regex("^[0-9]+$");

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

            if (nameBox.Text.Trim().Equals("") || igredientsBox.Text.Trim().Equals("") || quantityBox.Text.Trim().Equals("") || commentBox.Text.Trim().Equals(""))
            {
                allError.Foreground= System.Windows.Media.Brushes.Red;
                buttonCORRECT.IsEnabled = false;
            }else if (!regex.IsMatch(quantityBox.Text))
            {
                errrType.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
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
                    List<Model.Medicine> rooms = medicineService.FindInvalidMedicine();

                    rooms.Remove(selectedMedicine);
                    if (selectedMedicine != null)
                    {
                        dataGridMedicinesCorrect.ItemsSource = rooms;
                        dataGridMedicinesCorrect.Items.Refresh();
                    }
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);


                }
            }

        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Report());
        }


        private void Button_Click_CHOOSE(object sender, RoutedEventArgs e)
        {
            selectedMedicine = (Model.Medicine)dataGridMedicinesCorrect.SelectedItem;

            if (selectedMedicine == null)
            {
                chooseError.Foreground = System.Windows.Media.Brushes.Red;
                buutonChoose.IsEnabled = false;
                buttonCORRECT.IsEnabled = false;
            }
            else
            {


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

        private void dataGridMedicinesCorrect_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            chooseError.Foreground = System.Windows.Media.Brushes.LightGray;
            buutonChoose.IsEnabled = true;
            buttonCORRECT.IsEnabled = true;
        }

        private void nameBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonCORRECT.IsEnabled = true;
        }

        private void quantityBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonCORRECT.IsEnabled = true;
            errrType.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void igredientsBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonCORRECT.IsEnabled = true;
        }

        private void commentBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            allError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonCORRECT.IsEnabled = true;
        }

        private void quantityBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(quantityBox.Text))
            {
                errrType.Foreground = System.Windows.Media.Brushes.Red;

            }
        }
    }
}
