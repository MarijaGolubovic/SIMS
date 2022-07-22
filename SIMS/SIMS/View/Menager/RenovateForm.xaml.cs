using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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
            buttonRenovate.IsEnabled =false;
            buttnMerge.IsEnabled = false;
            buttonSplit.IsEnabled = false;

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

            if (DatePickerBegin.SelectedDate == null && DatePickerEnd.SelectedDate == null && renovationMethod.Text.Trim().Equals(""))
            {
                buttonSplit.IsEnabled = false;
                buttnMerge.IsEnabled = false;
            }
            else
            {
                buttonRenovate.IsEnabled = true;
                if (DatePickerBegin.SelectedDate == null)
                {
                    beginDateError.Foreground = System.Windows.Media.Brushes.Red;
                    buttonRenovate.IsEnabled = false;
                    buttnMerge.IsEnabled = false;
                    buttonSplit.IsEnabled = false;
                }
                else if (DatePickerEnd.SelectedDate == null)
                {
                    endDateError.Foreground = System.Windows.Media.Brushes.Red;
                    buttonRenovate.IsEnabled = false;
                    buttnMerge.IsEnabled = false;
                    buttonSplit.IsEnabled = false;
                }
                else if (renovationMethod.Text.Trim().Equals(""))
                {
                    methodError.Foreground = System.Windows.Media.Brushes.Red;
                    buttonRenovate.IsEnabled = false;
                    buttnMerge.IsEnabled = false;
                    buttonSplit.IsEnabled = false;
                }
                else
                {


                    if (occupacyRoomService.IsEndBeforeBegin(DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value))
                    {

                        feedbackMessage.Text = "End before begin!";
                        feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessage);

                    }

                    else if (occupacyRoomService.RoomAlreadyOccupacy(roomItem, DatePickerBegin.SelectedDate.Value, DatePickerEnd.SelectedDate.Value, renovationMethod.Text))
                    {
                        feedbackMessage.Text = "Room occypaced in this period!";
                        feedbackMessage.Foreground = System.Windows.Media.Brushes.Red;
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessage);

                    }

                    else
                    {

                        feedbackMessage.Text = "Room added to renovation list!";
                        feedbackMessage.Foreground = System.Windows.Media.Brushes.Green;
                        Storyboard sb = Resources["sbHideAnimation"] as Storyboard;
                        sb.Begin(feedbackMessage);

                    }

                    //this.NavigationService.Navigate(new Report());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SplitRoom());
        }

        private void Button_Click_MergeRooms(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MergeRooms());
        }

        private void DatePickerBegin_GotFocus(object sender, RoutedEventArgs e)
        {
            beginDateError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonRenovate.IsEnabled = true;
            

        }

        private void DatePickerEnd_GotFocus(object sender, RoutedEventArgs e)
        {
            endDateError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonRenovate.IsEnabled = true;
            
        }

        private void renovationMethod_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            methodError.Foreground = System.Windows.Media.Brushes.LightGray;
            buttonRenovate.IsEnabled = true;
            buttnMerge.IsEnabled = true;
            buttonSplit.IsEnabled = true;
        }
    }
}
