using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Page
    {
        Repository.MedicineStorage medicineStorage = new Repository.MedicineStorage();

        public AddMedicine()
        {
            InitializeComponent();
        }


        private void Button_Click_OKAddMedicine(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("([0-9]+\\.?[0-9]*)");

            if (nameBox.Text.Trim().Equals("") && ingredientsBox.Text.Trim().Equals("") && quantityBox.Text.Trim().Equals(""))
            {
                allErrors.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {

                if (nameBox.Text.Trim().Equals(""))
                {
                    errorName.Foreground = System.Windows.Media.Brushes.Red;
                }
                else if (ingredientsBox.Text.Trim().Equals(""))
                {
                    errorIgredients.Foreground = System.Windows.Media.Brushes.Red;
                }
                else if (quantityBox.Text.Trim().Equals(""))
                {
                    errorQuantity.Foreground = System.Windows.Media.Brushes.Red;

                }
                else if (!regex.IsMatch(quantityBox.Text))
                {
                    invalidType.Foreground = System.Windows.Media.Brushes.Red;
                    e.Handled = regex.IsMatch(quantityBox.Text);
                }
                else
                {


                    string name = nameBox.Text;
                    string ingredentsInput = ingredientsBox.Text;
                    int quantity = int.Parse(quantityBox.Text);
                    List<String> ingredients = new List<String>();
                    string[] tokens = ingredentsInput.Trim().Split(',');
                    for (int i = 0; i < tokens.Length; i++)
                    {
                        ingredients.Add(tokens[i]);
                    }



                    medicineStorage.Create(new Model.Medicine(name, ingredients, Model.MedicineStatus.OnHold, quantity));
                    this.NavigationService.Navigate(new View.Menager.MedecineList());


                    // MessageBox.Show("Medicine succesfully added!");
                }
            }
        }

        private void Button_Click_CANCELAddMedicine(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }

       

        private void ingredientsBox_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            errorIgredients.Foreground = System.Windows.Media.Brushes.LightGray;
            allErrors.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void nameBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            errorName.Foreground = System.Windows.Media.Brushes.LightGray;
            allErrors.Foreground = System.Windows.Media.Brushes.LightGray;
        }

       

        private void quantityBox_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            errorQuantity.Foreground = System.Windows.Media.Brushes.LightGray;
            allErrors.Foreground = System.Windows.Media.Brushes.LightGray;
            invalidType.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Tutorials.AddMedicineTutorial());
        }
    }
}
