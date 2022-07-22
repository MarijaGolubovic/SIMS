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
    /// Interaction logic for OrderingEquipment.xaml
    /// </summary>
    public partial class OrderingEquipment : Page
    {
        public static ObservableCollection<Model.Equpment> Equipment { get; set; }
        public static Model.Equpment selectedItem;
        public OrderingEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            Equipment = new ObservableCollection<Model.Equpment>();
            Equipment.Add(new Model.Equpment("Skalpel",12));
            Equipment.Add(new Model.Equpment("Zavoj", 100));
            Equipment.Add(new Model.Equpment("Sterilne komprese", 1500));
            Equipment.Add(new Model.Equpment("Pinceta", 15));
            Equipment.Add(new Model.Equpment("Sterilni stapici", 2500));
            Equipment.Add(new Model.Equpment("Pipeta", 50));
            buttonAllow.IsEnabled = false;

        }

        private void buttonChoose_CHOOSE(object sender, RoutedEventArgs e)
        {
            selectedItem = (Model.Equpment)DataGridOrdering.SelectedItem;
            if (selectedItem != null)
            {
                buttonChoose.IsEnabled = true;
                buttonAllow.IsEnabled = true;
                equipmentBox.Text = selectedItem.Name;
                quantityBox.Text = selectedItem.Quantity.ToString();
            }
            else
            {
                errorMessage.Foreground = System.Windows.Media.Brushes.Red;
                buttonChoose.IsEnabled = false;
                buttonAllow.IsEnabled = false;
            }
        }

        private void DataGridOrdering_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonChoose.IsEnabled = true;
           

        }

        private void Button_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menager.Report());
        }

        private void buttonAllow_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (Model.Equpment)DataGridOrdering.SelectedItem;
            buttonAllow.IsEnabled = true;
            if (selectedItem == null)
            {
                buttonAllow.IsEnabled = false;
            }
            Equipment.Remove(selectedItem);
            if (selectedItem != null)
            {
                DataGridOrdering.ItemsSource = Equipment;
                DataGridOrdering.Items.Refresh();
                equipmentBox.Text = "";
                quantityBox.Text = "";
                
            }

            feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
            Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
            sb.Begin(feedbackMessage);
            buttonAllow.IsEnabled = false;
        }

        private void Button_Click_TUTOTIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Tutorials.OrderingEquipmentTutorial());
        }
    }
}
