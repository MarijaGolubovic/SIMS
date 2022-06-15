using System.Windows.Input;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

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

       

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
                //Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
                Regex regex = new Regex("^[0-9]+$");

                if (nameBox.Text.Trim().Equals("") || quantityBox.Text.Trim().Equals("") || igredientsBox.Text.Trim().Equals("")) {
                    errorEmptyFields.Foreground = System.Windows.Media.Brushes.Red;
                    
                } else if (!regex.IsMatch(quantityBox.Text))
                {
                    typeError.Foreground = System.Windows.Media.Brushes.Red;
                    errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
                }
                else {
                    editButton.IsEnabled = true;
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
                    errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
                    nameBox.Text = "";
                    quantityBox.Text = "";
                    igredientsBox.Text = "";
                }
            }
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }

        private void Button_Click_CHOSE(object sender, RoutedEventArgs e)
        {
            selectedMedicine = (Model.Medicine)dataGridMedicines.SelectedItem;
            if (selectedMedicine == null)
            {
                chooseError.Foreground= System.Windows.Media.Brushes.Red;
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


                nameBox.Text = selectedMedicine.Name;
                quantityBox.Text = selectedMedicine.Quantity.ToString();
                igredientsBox.Text = igredients;
                flag = true;
            }
        }

        private void dataGridMedicines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            chooseError.Foreground = System.Windows.Media.Brushes.LightGray;
            errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void quantityBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            Regex regex = new Regex("^[0-9]+$");
            if (!regex.IsMatch(quantityBox.Text))
            {
                typeError.Foreground = System.Windows.Media.Brushes.Red;
                errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
            }
        }


        private void nameBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void igredientsBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void quantityBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            errorEmptyFields.Foreground = System.Windows.Media.Brushes.LightGray;
            typeError.Foreground = System.Windows.Media.Brushes.LightGray;
        }
    }
}
