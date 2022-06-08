using SIMS.Controller;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.Generic;
using System;
using GalaSoft.MvvmLight.Messaging;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class EditRoomViewModel : BindableBase
    {
        public MyICommand EditCommand { get; set; }
        public List<Room> Rooms { get; set; }
        private Room selectedRoom;
        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set { selectedRoom = value; }
        }

        private readonly AppointmentController appointmentController = new AppointmentController();
        //komentar
        public EditRoomViewModel()
        {
            Rooms = appointmentController.FindRoomsForEditAppointment(ViewModel.Doctor.EditAppointmentViewModel.SelectedAppointment);
            EditCommand = new MyICommand(OnEdit);
        }

        private void OnEdit()
        {
            appointmentController.EditRoom(ViewModel.Doctor.EditAppointmentViewModel.SelectedAppointment.appointmentId, SelectedRoom);
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
            Messenger.Default.Send("EditAppointmentView");
        }
    }
}
