using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for RenovateForm.xaml
    /// </summary>
    public partial class RenovateForm : Page
    {
        public static System.Collections.ObjectModel.ObservableCollection<Model.Room> RoomRenovate { get; set; }
        Model.Room roomItem;
        private static readonly SIMS.Service.OccupacyRoomService occupacyRoomService = new Service.OccupacyRoomService();


        public RenovateForm()
        {
            roomItem = Menager.RenovateWindow.selectedRoom;
            InitializeComponent();

            idRenovateRoom.Text = roomItem.Id;
            sizeRenovateRoom.Text = roomItem.Size.ToString();
            TypeRenovateRoom.Text = roomItem.Type.ToString();

        }

        private void Label_MouseDoubleClickRooms(object sender, MouseButtonEventArgs e)
        {
            Menager.RenovateForm renovateForm = new RenovateForm();
            // renovateForm.Show();
            // this.Close();
        }

        private void Button_Click_CANCEL(object sender, RoutedEventArgs e)
        {
            Menager.RenovateWindow renovateWindow = new RenovateWindow();
            // renovateWindow.Show();
            // this.Close();
            this.NavigationService.Navigate(new RenovateWindow());
        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            roomItem = Menager.RenovateWindow.selectedRoom;

            //            string message= occupacyRoomService.RenovateRoom(roomItem, DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, renovationMethod.Text);

            if (occupacyRoomService.EndBeforeBegin(DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value))
            {
                MessageBox.Show("End before begin!");
            }

            else if (occupacyRoomService.RoomAlreadyOccupacy(roomItem, DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, renovationMethod.Text))
            {
                MessageBox.Show("Room occypaced in this period!");
            }

            else { MessageBox.Show("Room added to renoavtion list!"); }




            //this.Close();


            this.NavigationService.Navigate(new Report());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SplitRoom());
        }

        private void Button_Click_MergeRooms(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MergeRooms());
        }
    }
}
