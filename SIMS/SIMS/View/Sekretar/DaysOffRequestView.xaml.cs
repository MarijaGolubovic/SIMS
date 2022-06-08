using SIMS.ViewModel.Sekretar;
using System;
using System.Windows;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for DaysOffRequestView.xaml
    /// </summary>
    public partial class DaysOffRequestView : Window
    {
        public DaysOffRequestViewModel DaysOffRequestViewModel { get; set; }
        public DaysOffRequestView()
        {
            InitializeComponent();
            this.DaysOffRequestViewModel = new DaysOffRequestViewModel();
            this.DataContext = this.DaysOffRequestViewModel;
            if (DaysOffRequestViewModel.CloseAction == null)
                DaysOffRequestViewModel.CloseAction = new Action(this.Close);


        }
    }
}
