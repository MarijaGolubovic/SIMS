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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for EditMedicine.xaml
    /// </summary>
    public partial class EditMedicine : Window
    {
        public static ObservableCollection<Model.Medicine> Rooms { get; set; }
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

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
