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
