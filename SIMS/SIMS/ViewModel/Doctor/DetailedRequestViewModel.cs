using System;
using SIMS.Model;

namespace SIMS.ViewModel.Doctor
{
    internal class DetailedRequestViewModel : BindableBase
    {
        public DaysOffRequest SelectedRequest { get; set; }

        public String Status { get; set; }

        public DetailedRequestViewModel()
        {
            SelectedRequest = AllRequirentmentsViewModel.SelectedRequest;
            if (SelectedRequest.RequestStatus == RequestStatus.onHold)
            {
                Status = "Na čekanju";
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
    }
}
