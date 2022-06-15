using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace SIMS.Menager
{
    /// <summary>
    /// Interaction logic for UpdateForm.xaml
    /// </summary>
    public partial class UpdateForm : Page

    {
        Model.Room roomItem;
        public static ObservableCollection<Model.Room> Rooms { get; set; }

        public UpdateForm()
        {
            roomItem = Menager.UpdateRoomWindow.selectedRoom;
            InitializeComponent();
            IDInput.Text = roomItem.Size.ToString();
            SizeInput.Text = roomItem.Id;


            if (roomItem.Type.Equals(Model.RoomType.OPPERATING_ROOM))
            {
                comboboxField.SelectedIndex = 0;
            }
            else if (roomItem.Type.Equals(Model.RoomType.EXAMINATION_ROOM))
            {
                comboboxField.SelectedIndex = 1;
            }
            else if (roomItem.Type.Equals(Model.RoomType.HOSPITAL_ROOM))
            {
                comboboxField.SelectedIndex = 2;
            }
            else
            {
                comboboxField.SelectedIndex = 3;
            }




        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            //this.Close();
            this.NavigationService.Navigate(new View.Menager.Report());
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

            Serialization.Serializer<Model.Room> roomSerializer = new Serialization.Serializer<Model.Room>();
            List<Model.Room> rooms = roomSerializer.fromCSV("Room.txt");
            RoomsList.Rooms = new ObservableCollection<Model.Room>();


            foreach (Model.Room roomIterator in rooms)
            {
                RoomsList.Rooms.Add(roomIterator);
            }
            if (SizeInput.Text.Trim().Equals("") || IDInput.Text.Trim().Equals(""))
            {
                erroeEmpty.Foreground= System.Windows.Media.Brushes.Red;
            }
            else
            {
                erroeEmpty.Foreground = System.Windows.Media.Brushes.LightGray;
                Model.RoomType roomType = Model.RoomType.HOSPITAL_ROOM;
                if (comboboxField.SelectedIndex == 0)
                {
                    roomType = Model.RoomType.OPPERATING_ROOM;
                }
                else if (comboboxField.SelectedIndex == 1)
                {
                    roomType = Model.RoomType.EXAMINATION_ROOM;
                }
                else if (comboboxField.SelectedIndex == 2)
                {
                    roomType = Model.RoomType.HOSPITAL_ROOM;
                }
                else
                {
                    roomType = Model.RoomType.WAREHOUSE;
                }



                Model.Room newRoom = (new Model.Room { Id = SizeInput.Text, Size = Double.Parse(IDInput.Text), Type = roomType });
                RoomsList.Rooms.RemoveAt(Menager.UpdateRoomWindow.indexSelected);
                RoomsList.Rooms.Add(newRoom);

                roomSerializer.toCSV("Room.txt", RoomsList.Rooms.ToList());


                //    Menager.UpdateRoomWindow updateRoomWindow = new UpdateRoomWindow();
                //  updateRoomWindow.Show();
                //this.Close();
                this.NavigationService.Navigate(new View.Menager.SuccesfullyUpdate());
            }
        }

        private void SizeInput_GotFocus(object sender, RoutedEventArgs e)
        {
            erroeEmpty.Foreground = System.Windows.Media.Brushes.LightGray;
        }

        private void IDInput_GotFocus(object sender, RoutedEventArgs e)
        {
            erroeEmpty.Foreground = System.Windows.Media.Brushes.LightGray;
        }


        private void IDInput_GotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            invalidDataInput.Foreground = System.Windows.Media.Brushes.LightGray;
            
        }

        private void IDInput_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            if (!regex.IsMatch(IDInput.Text))
            {
                invalidDataInput.Foreground = System.Windows.Media.Brushes.Red;

            }
        }

        
    }
}
