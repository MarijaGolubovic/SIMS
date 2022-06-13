using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for DeleteMedicine.xaml
    /// </summary>
    public partial class DeleteMedicine : Page
    {
        public static ObservableCollection<Model.Medicine> Medicines { get; set; }

        public static Model.Medicine selectedItem;
        Repository.MedicineStorage medicineStorage = new Repository.MedicineStorage();
        List<Model.Medicine> allMedicines;


        public DeleteMedicine()
        {
            InitializeComponent();
            this.DataContext = this;
            Medicines = new ObservableCollection<Model.Medicine>();
            allMedicines = medicineStorage.GetAll();
            foreach (Model.Medicine roomItem in allMedicines)
            {
                Medicines.Add(roomItem);
            }
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Menager.Report());
        }

        private void Button_Click_DELETE(object sender, RoutedEventArgs e)
        {
            selectedItem =(Model.Medicine) dataGridMedicines.SelectedItem;
            

            Serialization.Serializer<Model.Medicine> medicinceSerializer = new Serialization.Serializer<Model.Medicine>();
            if (selectedItem != null)
            {
                allMedicines.Remove(selectedItem);
                deleteButton.IsEnabled = true;

                if (selectedItem != null)
                {
                    allMedicines.Remove(selectedItem);
                    dataGridMedicines.ItemsSource = allMedicines;
                    dataGridMedicines.Items.Refresh();
                }
                feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                sb.Begin(feedbackMessage);
                medicinceSerializer.toCSV("medicine.txt", allMedicines);
                errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
            }
            else
            {

                errorMessage.Foreground = System.Windows.Media.Brushes.Red;
                deleteButton.IsEnabled = false;
            }

        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Tutorials.DeleteMedicineTutorial());
        }

        private void dataGridMedicines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
            deleteButton.IsEnabled = true;
        }
    }
}
