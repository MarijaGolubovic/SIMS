using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SIMS.Model;
namespace SIMS.View.Menager
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public static ObservableCollection<Model.Report> ReportData { get; set; }
        String sectedDate = "";
        List<Model.Report> allReport = new List<Model.Report>();
        int date = 0;
        public Report()

        {
            InitializeComponent();
            this.DataContext = this;
            
            ReportData = new ObservableCollection<Model.Report>();

            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
         

            foreach (Model.Report report in allReport)
            {
                ReportData.Add(report);
            }

            
        }

    }
}
