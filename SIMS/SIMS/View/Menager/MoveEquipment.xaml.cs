using System;
using System.Collections.Generic;
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
    /// Interaction logic for MoveEquipment.xaml
    /// </summary>
    public partial class MoveEquipment : Window
    {

        Service.RoomEquipmentServices roomEquipmentServices = new Service.RoomEquipmentServices();
        public static System.Collections.ObjectModel.ObservableCollection<Model.Equpment> MoveEquipmentObservable { get; set; }

        public MoveEquipment()
        {
            InitializeComponent();
            this.DataContext = this;

            Serialization.Serializer<Model.Equpment> equpmentSerializer = new Serialization.Serializer<Model.Equpment>();
            List<Model.Equpment> equipments = equpmentSerializer.fromCSV("Equipment.txt");
            MoveEquipmentObservable = new System.Collections.ObjectModel.ObservableCollection<Model.Equpment>();

            foreach(Model.Equpment equipmentItem in equipments)
            {
                MoveEquipmentObservable.Add(equipmentItem);
            }


            RoomChoose1.Text = Rooms.roomItemSelected.Id;


        }

        private void DataGridEquipment_PreviewMouseDoubleClickEquipment(object sender, MouseButtonEventArgs e)
        {
            Model.Equpment selectedEquipment = (Model.Equpment)DataGridUpdate.SelectedItem;
            EquipmentBox.Text = selectedEquipment.Name;
        }

        private void OkButton_MoveEquipment(object sender, RoutedEventArgs e)
        {
            string idRoom = Rooms.roomItemSelected.Id;
            string equipmentName = EquipmentBox.Text;
            string destination = destinationBox.Text;
            string begin = beginBox.Text;
            string end = endBox.Text;
            string equipnemtId="";
            Serialization.Serializer<Model.RoomEqupment> equpmentSerializer = new Serialization.Serializer<Model.RoomEqupment>();
            List<Model.RoomEqupment> equipments = equpmentSerializer.fromCSV("RoomEquipment.txt");

            Serialization.Serializer<Model.Equpment> equpmentSerializerPom = new Serialization.Serializer<Model.Equpment>();
            List<Model.Equpment> equipmentsPom = equpmentSerializerPom.fromCSV("Equipment.txt");
            List<Model.RoomEqupment> something = new List<Model.RoomEqupment>();

            bool flag = false;
            foreach (Model.Equpment eqPom in equipmentsPom)
            
            {
                if (eqPom.Name.Equals(equipmentName))
                {
                    equipnemtId = eqPom.Id;
                }
            }

            something.Add(new Model.RoomEqupment("soba2","r1","12-May-2022"));

            foreach (Model.RoomEqupment eqr in something)
            {
                if ((equipnemtId).Equals(eqr.IdEquipment))
                {
                    flag = true;
                }
            }

            if (DateTime.Compare(DateTime.Parse(end), DateTime.Parse(begin)) < 0)
            {
                MessageBox.Show("End before began!");
            } 
            if (flag)
            {

                MessageBox.Show("Equipment already move!");
            }
            else
            {
                   something.Add(new Model.RoomEqupment(idRoom, equipnemtId, begin + "" + end));
                    MessageBox.Show("Equipment succesfully moved!");
                    
                
               
            }
        }
    }
}
