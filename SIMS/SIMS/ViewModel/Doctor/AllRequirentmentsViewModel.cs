using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.ViewModel.Doctor
{
    internal class AllRequirentmentsViewModel : BindableBase
    {
        public List<DaysOffRequest> DaysOffRequirentments { get; set; }
        private readonly DaysOffRequestController daysOffRequestController = new DaysOffRequestController();

        public static MyICommand Back { get; set; }
        public static MyICommand ShowDetailsCommand { get; set; }

        private static DaysOffRequest selectedRequest;

        public static DaysOffRequest SelectedRequest
        {
            get { return selectedRequest; }
            set
            {
                selectedRequest = value;
                ShowDetailsCommand.RaiseCanExecuteChanged();
            }
        }

        public AllRequirentmentsViewModel()
        {
            DaysOffRequirentments = daysOffRequestController.GetAllRequirementsForDoctor();
            Back = new MyICommand(OnBack);
            ShowDetailsCommand = new MyICommand(OnShowDetails, CanShowDetails);
        }

        private void OnBack()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
        private void OnShowDetails()
        {
            Messenger.Default.Send("DetailedRequest");
        }

        private bool CanShowDetails()
        {
            return SelectedRequest != null;
        }
    }
}
