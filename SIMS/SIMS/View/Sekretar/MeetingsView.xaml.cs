using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SIMS.ViewModel.Sekretar;

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
