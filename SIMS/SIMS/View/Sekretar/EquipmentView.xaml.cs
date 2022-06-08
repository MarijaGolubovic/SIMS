using SIMS.ViewModel.Sekretar;
using System;
using System.Windows;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for EquipmentView.xaml
    /// </summary>
    public partial class EquipmentView : Window
    {
        public EquipmentViewModel EquipmentViewModel { get; set; }
        public EquipmentView()
        {
            InitializeComponent();
            this.EquipmentViewModel = new EquipmentViewModel();
            this.DataContext = this.EquipmentViewModel;
            if (EquipmentViewModel.CloseAction == null)
                EquipmentViewModel.CloseAction = new Action(this.Close);
        }


    }
}
