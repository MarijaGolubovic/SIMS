using System.Windows.Input;
using System.Windows;
using System.Collections.Generic;
using System;
using SIMS.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for MoveEquipment.xaml
    /// </summary>
    public partial class MoveEquipment : Page
    {

        Service.RoomEquipmentServices roomEquipmentServices = new Service.RoomEquipmentServices();
        public static System.Collections.ObjectModel.ObservableCollection<Model.Equpment> MoveEquipmentObservable { get; set; }
        string destination;
        string endString;
        string beginString;
        public MoveEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
            
           

            Serialization.Serializer<Model.Equpment> equpmentSerializer = new Serialization.Serializer<Model.Equpment>();
            List<Model.Equpment> equipments = equpmentSerializer.fromCSV("Equipment.txt");
            MoveEquipmentObservable = new System.Collections.ObjectModel.ObservableCollection<Model.Equpment>();
            buttonCOOSE.IsEnabled = false;
            foreach (Model.Equpment equipmentItem in equipments)
            {
                MoveEquipmentObservable.Add(equipmentItem);
            }


            RoomChoose1.Text = Rooms.roomItemSelected.Id;


        }

        private void OkButton_MoveEquipment(object sender, RoutedEventArgs e)
        {
            string idRoom = Rooms.roomItemSelected.Id;
            string equipmentName = EquipmentBox.Text;
            
            beginString = beginPeriod.SelectedDate.ToString();
            endString = endPeriod.SelectedDate.ToString();
            string equipnemtId = "";

           

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

            something.Add(new Model.RoomEqupment("soba2", "r1", "12-May-2022"));

            foreach (Model.RoomEqupment eqr in something)
            {
                if ((equipnemtId).Equals(eqr.IdEquipment))
                {
                    flag = true;
                }
            }


            if (endPeriod.SelectedDate == null)
            {

                endError.Foreground = System.Windows.Media.Brushes.Red;
                OkButton.IsEnabled = false;
            }
            
            

                if (destinationCombo.SelectedItem == null ||
                  beginPeriod.SelectedDate == null || endPeriod.SelectedDate == null || EquipmentBox.Text == "" 
                  || DataGridUpdate.SelectedItem==null)
                {

                    okError.Foreground = System.Windows.Media.Brushes.Red;
                    Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                    sb.Begin(okError);

                }
                else
                {



                    if (DateTime.Compare(DateTime.Parse(endString), DateTime.Parse(beginString)) < 0)
                    {
                        feedbackMessageBox.Text = "The end begins before the end!";
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessageBox);
                        feedbackMessageBox.Foreground = System.Windows.Media.Brushes.Red;
                    }
                    else if (flag)
                    {

                        feedbackMessageBox.Text = "Equipment already moved!";
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessageBox);
                        feedbackMessageBox.Foreground = System.Windows.Media.Brushes.Red;
                    }
                    else
                    {
                        something.Add(new Model.RoomEqupment(idRoom, equipnemtId, beginString + "" + endString));
                        feedbackMessageBox.Text = "Equipment succesfully moved!";
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessageBox);
                        feedbackMessageBox.Foreground = System.Windows.Media.Brushes.Green;
                    }
                }
            
        }

        private void Button_Click_SEARCHEquipment(object sender, RoutedEventArgs e)
        {
            string inputSearchContent = searchFiled.Text;

            if (!(inputSearchContent.Length == null))
            {
                List<Model.Equpment> searchedEquipment = new List<Model.Equpment>();
                searchedEquipment.Clear();
                MoveEquipmentObservable.Clear();
                searchedEquipment = roomEquipmentServices.SearchEquipment(inputSearchContent);
                foreach (Model.Equpment equipmentItem in searchedEquipment)
                {
                    MoveEquipmentObservable.Add(equipmentItem);
                }
            }
            else
            {
                Serialization.Serializer<Model.Equpment> equpmentSerializer = new Serialization.Serializer<Model.Equpment>();
                List<Model.Equpment> equipments = equpmentSerializer.fromCSV("Equipment.txt");
                MoveEquipmentObservable = new System.Collections.ObjectModel.ObservableCollection<Model.Equpment>();

                foreach (Model.Equpment equipmentItem in equipments)
                {
                    MoveEquipmentObservable.Add(equipmentItem);
                }
            }
        }

        private void CancelButon_BACK(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Rooms());
        }

        private void Button_Click_COOSE(object sender, RoutedEventArgs e)
        {
            Model.Equpment selectedEquipment = (Model.Equpment)DataGridUpdate.SelectedItem;
            if (selectedEquipment == null)
            {
                cooseError.Foreground = System.Windows.Media.Brushes.Red;
                buttonCOOSE.IsEnabled = false;
            }
            else
            {

                EquipmentBox.Text = selectedEquipment.Name;
            }
        }


        private void destinationCombo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EquipmentBox.Text.Trim().Equals(""))
            {
                EquipmentBox.Text = "Coose equipment!";
                EquipmentBox.Foreground = System.Windows.Media.Brushes.Red;
               
                

            }
            
            destinationError.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void DataGridUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cooseError.Foreground = System.Windows.Media.Brushes.LightGray;
            EquipmentBox.Foreground = System.Windows.Media.Brushes.Black;
            EquipmentBox.Text = "";


            buttonCOOSE.IsEnabled = true;
        }


        private void beginPeriod_GotFocus(object sender, RoutedEventArgs e)
        {
            beginError.Foreground = System.Windows.Media.Brushes.LightGray;
            if (destinationCombo.SelectedItem == null)
            {
                destinationError.Foreground = System.Windows.Media.Brushes.Red;
            }
            beginString = beginPeriod.SelectedDate.ToString();
        }

        private void endPeriod_GotFocus(object sender, RoutedEventArgs e)
        {

            if (beginPeriod.SelectedDate == null)
            {
                beginError.Foreground = System.Windows.Media.Brushes.Red;
            }
            endError.Foreground = System.Windows.Media.Brushes.LightGray;
            OkButton.IsEnabled = true;
            endString = endPeriod.SelectedDate.ToString();
        }

        private void destinationCombo_MouseEnter(object sender, MouseEventArgs e)
        {
            destinationError.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void destinationCombo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            destination = destinationCombo.SelectedItem.ToString();
        }
    }
}
