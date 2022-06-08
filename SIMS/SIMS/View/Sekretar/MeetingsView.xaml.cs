using SIMS.ViewModel.Sekretar;
using System;
using System.Windows;

namespace SIMS.View.Sekretar
{
    /// <summary>
    /// Interaction logic for MeetingsView.xaml
    /// </summary>
    public partial class MeetingsView : Window
    {
        public MeetingsViewModel MeetingsViewModel { get; set; }
        public MeetingsView()
        {
            InitializeComponent();
            this.MeetingsViewModel = new MeetingsViewModel();
            this.DataContext = this.MeetingsViewModel;
            if (MeetingsViewModel.CloseAction == null)
                MeetingsViewModel.CloseAction = new Action(this.Close);
        }
    }
}
