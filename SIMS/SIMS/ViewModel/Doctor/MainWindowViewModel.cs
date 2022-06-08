using SIMS.Controller;
using SIMS.Model;
using SIMS.Controller;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using ToastNotifications;
using System;
using ToastNotifications.Messages;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace SIMS.ViewModel.Doctor
{
    internal class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;

        private AppointmentController appointmentController = new AppointmentController();
        private readonly MedicineContoller medicineContoller = new MedicineContoller();

        private AllAppointmentsViewModel allAppointmentsViewModel = new AllAppointmentsViewModel();
        private DaysOffRequestViewModel daysOffRequestViewModel = new DaysOffRequestViewModel();
        private MedicineValidationViewModel medicineValidationViewModel = new MedicineValidationViewModel();
        private AllRequirentmentsViewModel allRequirentmentsViewModel = new AllRequirentmentsViewModel();
        private VacationRequestViewModel vacationRequestViewModel = new VacationRequestViewModel();
        private EditAccountViewModel editAccountViewModel = new EditAccountViewModel();
        private AccountViewModel accountViewModel = new AccountViewModel();
        private ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();
        private DetailedRequestViewModel detailedRequestViewModel;
        private AddAppointmentViewModel AddAppointmentViewModel;
        private EditAppointmentViewModel editAppointmentViewModel = new EditAppointmentViewModel();
        private SuggestedAppointmentsViewModel suggestedAppointmentsViewModel;
        private EditRoomViewModel editRoomViewModel;
        private DetailedAppointmentViewModel detailedAppointmentViewModel;
        private JoinAppointmentViewModel joinAppointmentViewModel;
        private AddTherapyViewModel addTherapyViewModel;
        private AddOperationViewModel addOperationViewModel = new AddOperationViewModel();
        public static User LoggedInUser { get; set; }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public MainWindowViewModel()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjUwNTgzQDMyMzAyZTMxMmUzMGVRNS9RWVYvWTZ6blNQUE4vcnd2NmFkc3ZGeERTOStmb0x4dTRxbWdzMEE9");

            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = allAppointmentsViewModel;

            Messenger.Default.Register<String>(this, ChangeCurrentViewModel);
        }

        private void ChangeCurrentViewModel(String message)
        {
            switch (message)
            {
                case "DetailedAppointmentView":
                    detailedAppointmentViewModel = new DetailedAppointmentViewModel();
                    CurrentViewModel = detailedAppointmentViewModel;
                    break;
                case "JoinAppointmentView":
                    joinAppointmentViewModel = new JoinAppointmentViewModel();
                    CurrentViewModel = joinAppointmentViewModel;
                    break;
                case "AllAppointmentView":
                    CurrentViewModel = allAppointmentsViewModel;
                    break;
                case "AddTherapy":
                    addTherapyViewModel = new AddTherapyViewModel();
                    CurrentViewModel = addTherapyViewModel;
                    break;
                case "BackFromAddTherapyView":
                    joinAppointmentViewModel = new JoinAppointmentViewModel();
                    CurrentViewModel = joinAppointmentViewModel;
                    break;
                case "MedicineValidateView":
                    medicineValidationViewModel = new MedicineValidationViewModel();
                    CurrentViewModel = medicineValidationViewModel;
                    break;
                case "EditAppointmentView":
                    editAppointmentViewModel = new EditAppointmentViewModel();
                    CurrentViewModel = editAppointmentViewModel;
                    break;
                case "EditRoomView":
                    List<Room> Rooms = appointmentController.FindRoomsForEditAppointment(ViewModel.Doctor.EditAppointmentViewModel.SelectedAppointment);
                    if (Rooms == null)
                    {
                        ViewModel.Doctor.MainWindowViewModel.notifier.ShowInformation("Nema slobodnih soba u tom terminu!");
                        currentViewModel = editAppointmentViewModel;
                    }
                    else
                    {
                        editRoomViewModel = new EditRoomViewModel();
                        CurrentViewModel = editRoomViewModel;
                    }
                    break;
                case "DaysOffRequestView":
                    daysOffRequestViewModel = new DaysOffRequestViewModel();
                    CurrentViewModel = daysOffRequestViewModel;
                    break;
                case "SuggestedAppointmentsViewModel":
                    suggestedAppointmentsViewModel = new SuggestedAppointmentsViewModel();
                    CurrentViewModel = suggestedAppointmentsViewModel;
                    break;
                case "AddAppointmentView":
                    AddAppointmentViewModel = new AddAppointmentViewModel();
                    CurrentViewModel = AddAppointmentViewModel;
                    break;
                case "DetailedRequest":
                    detailedRequestViewModel = new DetailedRequestViewModel();
                    CurrentViewModel = detailedRequestViewModel;
                    break;
                case "allReqs":
                    CurrentViewModel = allRequirentmentsViewModel;
                    break;
                case "AccountView":
                    CurrentViewModel = accountViewModel;
                    break;

            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "daysOff":
                    MainWindowViewModel.notifier.ShowInformation("Zahtjev morate podnijeti makar dva dana prije početka odmora!");
                    CurrentViewModel = daysOffRequestViewModel;
                    break;
                case "MedicineValidationView":
                    if (medicineContoller.IsThereMedicineForValidation())
                        CurrentViewModel = medicineValidationViewModel;
                    else
                        MainWindowViewModel.notifier.ShowInformation("Trenutno nema lijekova za validaciju!");
                    break;
                case "AddAppointmentView":
                    AddAppointmentViewModel = new AddAppointmentViewModel();
                    CurrentViewModel = AddAppointmentViewModel;
                    break;
                case "EditAppointmentView":
                    editAppointmentViewModel = new EditAppointmentViewModel();
                    CurrentViewModel = editAppointmentViewModel;
                    break;
                case "AllAppointmentView":
                    CurrentViewModel = allAppointmentsViewModel;
                    break;
                case "allReqs":
                    CurrentViewModel = allRequirentmentsViewModel;
                    break;
                case "AddOperationView":
                    CurrentViewModel = addOperationViewModel;
                    break;
                case "VacationRequestView":
                    CurrentViewModel = vacationRequestViewModel;
                    break;
                case "AccountView":
                    CurrentViewModel = accountViewModel;
                    break;
                case "EditAccount":
                    CurrentViewModel = editAccountViewModel;
                    break;
                case "ChangePasswordView":
                    CurrentViewModel = changePasswordViewModel;
                    break;
            }
        }


        public static Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 18,
                offsetY: 112);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(5),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });

    }
}
