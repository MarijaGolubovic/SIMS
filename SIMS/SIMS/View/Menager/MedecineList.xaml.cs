using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for MedecineList.xaml
    /// </summary>
    public partial class MedecineList : Page
    {
        public static ObservableCollection<Model.Medicine> Medicines { get; set; }
        public MedecineList()
        {
            InitializeComponent();
            this.DataContext = this;
            Serialization.Serializer<Model.Medicine> medicinceSerializer = new Serialization.Serializer<Model.Medicine>();
            List<Model.Medicine> allMedicines = medicinceSerializer.fromCSV("medicine.txt");
            Medicines = new ObservableCollection<Model.Medicine>();

            foreach (Model.Medicine roomItem in allMedicines)
            {
                Medicines.Add(roomItem);
            }
        }

        private void Button_Click_BACK(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddMedicine());
        }
    }
}
