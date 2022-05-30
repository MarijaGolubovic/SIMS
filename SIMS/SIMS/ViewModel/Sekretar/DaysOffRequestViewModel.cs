using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Controller;
using SIMS.Model;

namespace SIMS.ViewModel.Sekretar
{
    public class DaysOffRequestViewModel : BindableBase
    {
        public static ObservableCollection<DaysOffRequestDTO> Zahtevi { get; set; }
        public Action CloseAction { get; set; }

        public MyICommand SubmitCMD { get; set; }

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

            foreach(DaysOffRequestDTO d in daysOffRequestController.GetAllDTO())
            {
                Zahtevi.Add(d);
            }
            SubmitCMD = new MyICommand(Submit);

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

    }
}
