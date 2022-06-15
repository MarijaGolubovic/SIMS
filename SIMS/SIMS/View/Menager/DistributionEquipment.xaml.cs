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
    /// Interaction logic for DistributionEquipment.xaml
    /// </summary>
    public partial class DistributionEquipment : Page
    {
        public static ObservableCollection<Model.Equpment> Equipment { get; set; }
        public static Model.Equpment selectedItem;
        public DistributionEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            Equipment = new ObservableCollection<Model.Equpment>();
            Equipment.Add(new Model.Equpment("Skalpel", 12));
            Equipment.Add(new Model.Equpment("Zavoj", 100));
            Equipment.Add(new Model.Equpment("Sterilne komprese", 1500));
            Equipment.Add(new Model.Equpment("Pinceta", 15));
            Equipment.Add(new Model.Equpment("Sterilni stapici", 2500));
            Equipment.Add(new Model.Equpment("Pipeta", 50));
            buttonDistribut.IsEnabled = false;
        }

        private void buttonDistribut_Click(object sender, RoutedEventArgs e)
        {
            if (distributionBox.Text.Trim().Equals("")) {
                errorQuantity.Foreground = System.Windows.Media.Brushes.Red;
                errorQuantity.Text = "Input quantity";
                
            }

            if (destinationCombo.SelectedItem == null)
            {
                errorRoom.Foreground = System.Windows.Media.Brushes.Red; 
            }
            int inputQuantity = int.Parse(distributionBox.Text);
            if (selectedItem.Quantity < inputQuantity)
            {
                errorQuantity.Foreground = System.Windows.Media.Brushes.Red;
                errorQuantity.Text = "Invalid quantity";
                
            }
            else if (selectedItem.Quantity > 0)
            {
                selectedItem.Quantity -= inputQuantity;

                if (selectedItem != null)
                {
                    DataGridDistribution.ItemsSource = Equipment;
                    DataGridDistribution.Items.Refresh();
                    errorQuantity.Foreground = System.Windows.Media.Brushes.LightGray;
                }
                if (distributionBox.Text != "" && destinationCombo.SelectedItem != null)
                {
                    feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(feedbackMessage);

                }
                else
                {
                    emptyFiend.Foreground = System.Windows.Media.Brushes.Red;

                }
            }

           

        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Menager.Report());
        }

        private void buttonChoose_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (Model.Equpment)DataGridDistribution.SelectedItem;
            if (selectedItem != null)
            {
                buttonChoose.IsEnabled = true;
                buttonDistribut.IsEnabled = true;
                equipmentBox.Text = selectedItem.Name;
                quantityBox.Text = selectedItem.Quantity.ToString();
                distributionBox.Text = "0";
            }
            else
            {
                errorMessage.Foreground = System.Windows.Media.Brushes.Red;
                buttonChoose.IsEnabled = false;
                buttonDistribut.IsEnabled = false;
            }
        }

        private void destinationCombo_GotFocus(object sender, RoutedEventArgs e)
        {
            errorRoom.Foreground = System.Windows.Media.Brushes.LightGray;
            emptyFiend.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void distributionBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            errorQuantity.Text = "Enter quantity";
            errorQuantity.Foreground = System.Windows.Media.Brushes.LightGray;
            emptyFiend.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void DataGridDistribution_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            errorMessage.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonChoose.IsEnabled = true;
        }

        private void Button_Click_TUTORIAL(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Tutorials.DistributionEquipmentTutorial());
        }
    }
}
