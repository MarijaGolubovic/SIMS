using GalaSoft.MvvmLight.Messaging;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Doctor
{
    internal class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private BindableBase currentViewModel;

        private AllAppointmentsViewModel allAppointmentsViewModel = new AllAppointmentsViewModel(); 
        private DaysOffRequestViewModel daysOffRequestViewModel = new DaysOffRequestViewModel();
        private MedicineValidationViewModel medicineValidationViewModel = new MedicineValidationViewModel();    
        private DetailedAppointmentViewModel detailedAppointmentViewModel;
        private JoinAppointmentViewModel joinAppointmentViewModel;
        private AddTherapyViewModel addTherapyViewModel;
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
                case "BackFromDetailedAppointmentView":
                    CurrentViewModel = allAppointmentsViewModel;
                    break;
                case "BackFromJoinAppointmentView":
                    CurrentViewModel = allAppointmentsViewModel;
                    break;
                case "FinishFromJoinAppointmentView":
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
                    CurrentViewModel = medicineValidationViewModel;
                    break;
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "daysOff":
                    CurrentViewModel = daysOffRequestViewModel;
                    break;
                case "MedicineValidationView":
                    CurrentViewModel = medicineValidationViewModel;
                    break;
            }
        }

    }
}
