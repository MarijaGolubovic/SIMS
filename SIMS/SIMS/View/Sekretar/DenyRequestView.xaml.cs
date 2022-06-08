using SIMS.Model;
using SIMS.ViewModel.Sekretar;
using System;
using System.Windows;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for DenyRequestView.xaml
    /// </summary>
    public partial class DenyRequestView : Window
    {
        private DenyRequestViewModel DenyRequestViewModel { get; set; }
        public DenyRequestView(DaysOffRequestDTO daysOffRequest)
        {
            InitializeComponent();
            this.DenyRequestViewModel = new DenyRequestViewModel(daysOffRequest);
            this.DataContext = DenyRequestViewModel;
            if (DenyRequestViewModel.CloseAction == null)
                DenyRequestViewModel.CloseAction = new Action(this.Close);
        }
    }
}
