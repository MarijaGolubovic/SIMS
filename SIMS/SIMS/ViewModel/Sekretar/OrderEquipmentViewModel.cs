using SIMS.Controller;
using SIMS.Model;
using SIMS.View.Sekretar;
using System;
using System.Collections.ObjectModel;

namespace SIMS.ViewModel.Sekretar
{
    class OrderEquipmentViewModel : BindableBase
    {
        public MyICommand SubmitCMD { get; set; }
        private SuppliesController suppliesController;
        private Supplies selectedSupplies;
        private String newOrder;
        public Action CloseAction { get; set; }



        public OrderEquipmentViewModel(Supplies supplies)
        {
            SubmitCMD = new MyICommand(SubmitOrder);
            suppliesController = new SuppliesController();
            selectedSupplies = supplies;
        }

        private void SubmitOrder()
        {
            //selectedSupplies.NewQuantity = int.Parse(newOrder);
            Supplies supplies = selectedSupplies;
            supplies.NewQuantity += int.Parse(newOrder);
            suppliesController.Update(supplies);
            CloseAction();
        }

        public String NewOrder
        {
            get { return newOrder; }
            set
            {
                newOrder = value;
            }
        }


    }
}

