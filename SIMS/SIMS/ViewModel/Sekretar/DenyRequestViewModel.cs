using SIMS.Controller;
using SIMS.Model;
using System;

namespace SIMS.ViewModel.Sekretar
{
    public class DenyRequestViewModel : BindableBase
    {
        public Action CloseAction { get; set; }
        public String Comment { get; set; }

        public DaysOffRequestDTO selectedItem;
        public MyICommand SubmitCMD { get; set; }

        public MyICommand CancelCMD { get; set; }


        private DaysOffRequestController daysOffRequestController;

        public DenyRequestViewModel(DaysOffRequestDTO daysOffRequestDTO)
        {
            selectedItem = daysOffRequestDTO;
            SubmitCMD = new MyICommand(Submit);
            CancelCMD = new MyICommand(Cancel);
            daysOffRequestController = new DaysOffRequestController();
        }

        private void Submit()
        {
            DaysOffRequestDTO daysOffRequestDTO = selectedItem;
            daysOffRequestDTO.Comment = Comment;
            daysOffRequestDTO.RequestStatus = RequestStatus.refused;
            daysOffRequestController.DenyRequest(daysOffRequestDTO);
            CloseAction();
        }

        private void Cancel()
        {
            CloseAction();
        }

    }
}
