using SIMS.Model;
using SIMS.ViewModel.Sekretar;
using System;
using System.Windows;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for OrderEquipmentView.xaml
    /// </summary>
    public partial class OrderEquipmentView : Window
    {
        OrderEquipmentViewModel OrderEquipmentViewModel { get; set; }
        public OrderEquipmentView(Supplies supplies)
        {
            InitializeComponent();
            this.OrderEquipmentViewModel = new OrderEquipmentViewModel(supplies);
            this.DataContext = OrderEquipmentViewModel;
            if (OrderEquipmentViewModel.CloseAction == null)
                OrderEquipmentViewModel.CloseAction = new Action(this.Close);

        }
    }
}
