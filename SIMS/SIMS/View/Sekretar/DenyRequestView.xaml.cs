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
using SIMS.Model;
using SIMS.ViewModel.Sekretar;

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
