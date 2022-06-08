using SIMS.Controller;
using SIMS.Model;
using SIMS.View.Sekretar;
using System;
using System.Collections.ObjectModel;

namespace SIMS.ViewModel.Sekretar
{
    public class DaysOffRequestViewModel : BindableBase
    {
        public static ObservableCollection<DaysOffRequestDTO> Zahtevi { get; set; }
        public Action CloseAction { get; set; }

        public MyICommand SubmitCMD { get; set; }

        public MyICommand DenyCMD { get; set; }

        private DaysOffRequestController daysOffRequestController;

        private DaysOffRequestDTO selectedItem;

        public DaysOffRequestDTO SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }

        public DaysOffRequestViewModel()
        {
            Zahtevi = new ObservableCollection<DaysOffRequestDTO>();
            daysOffRequestController = new DaysOffRequestController();

            foreach (DaysOffRequestDTO d in daysOffRequestController.GetAllDTO())
            {
                Zahtevi.Add(d);
            }
            SubmitCMD = new MyICommand(Submit);
            DenyCMD = new MyICommand(DenyRequest);

        }

        private void Submit()
        {
            daysOffRequestController.AcceptRequest(SelectedItem);
            Zahtevi.Clear();
            foreach (DaysOffRequestDTO d in daysOffRequestController.GetAllDTO())
            {
                Zahtevi.Add(d);
            }

        }

        private void DenyRequest()
        {
            DenyRequestView denyRequestView = new DenyRequestView(SelectedItem);
            denyRequestView.Show();
        }

    }
}
