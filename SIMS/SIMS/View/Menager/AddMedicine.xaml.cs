using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private void Button_Click_CANCELAddMedicine(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Report());
        }
    }
}
