using SIMS.Controller;
using SIMS.Model;
using SIMS.View.Sekretar;
using System;
using System.Collections.ObjectModel;

namespace SIMS.ViewModel.Sekretar
{
    public class EquipmentViewModel : BindableBase
    {
        public static ObservableCollection<Supplies> Oprema { get; set; }

        private SuppliesController suppliesController;
        public MyICommand UpdateCMD { get; set; }
        public MyICommand OrderCMD { get; set; }
        public MyICommand ToWarehouseCMD { get; set; }
        public MyICommand CloseCMD { get; set; }

        public Action CloseAction { get; set; }


        private Supplies selectedItem;


        public EquipmentViewModel()
        {
            Oprema = new ObservableCollection<Supplies>();
            suppliesController = new SuppliesController();
            foreach (Supplies e in suppliesController.GetAll())
            {
                Oprema.Add(e);
            }
            UpdateCMD = new MyICommand(OpenUpdateSupplies);
            OrderCMD = new MyICommand(OpenOrderEquipment);
            ToWarehouseCMD = new MyICommand(ToWarehouse);
            CloseCMD = new MyICommand(Close);

        }

        public Supplies SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }

        private void OpenUpdateSupplies()
        {
            UpdateEquipmentView updateEquipmentView = new UpdateEquipmentView();
            updateEquipmentView.Show();
        }

        private void OpenOrderEquipment()
        {
            OrderEquipmentView orderEquipmentView = new OrderEquipmentView(selectedItem);
            orderEquipmentView.Show();
        }

        private void ToWarehouse()
        {
            suppliesController.TransferToWarehouse(SelectedItem);
        }

        private void Close()
        {
            CloseAction();
        }


    }
}
