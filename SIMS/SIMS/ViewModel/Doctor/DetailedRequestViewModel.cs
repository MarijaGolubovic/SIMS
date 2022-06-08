using GalaSoft.MvvmLight.Messaging;
using SIMS.Model;
using System;

namespace SIMS.ViewModel.Doctor
{
    internal class DetailedRequestViewModel : BindableBase
    {
        public DaysOffRequest SelectedRequest { get; set; }
        public MyICommand BackCommand { get; set; }
        public String Status { get; set; }

        public DetailedRequestViewModel()
        {
            BackCommand = new MyICommand(OnBack);
            SelectedRequest = AllRequirentmentsViewModel.SelectedRequest;
            if (SelectedRequest.RequestStatus == RequestStatus.onHold)
            {
                Status = "Na čekanju";
                SelectedRequest.Comment = "/";
            }
            else if (SelectedRequest.RequestStatus == RequestStatus.accepted)
            {
                Status = "Odobreno";
            }
            else if (SelectedRequest.RequestStatus == RequestStatus.refused)
            {
                Status = "Odbijeno";
            }
        }

        private void OnBack()
        {
            Messenger.Default.Send("allReqs");
        }
    }
}
