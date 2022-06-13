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
        public  ObservableCollection<Model.Report> ReportData { get; set; }
       
        List<Model.Report> allReport = new List<Model.Report>();
        
        public Report()

        {
            InitializeComponent();
            
            
            ReportData = new ObservableCollection<Model.Report>();

            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));

            this.DataContext = this;
            foreach (Model.Report report in allReport)
            {
                ReportData.Add(report);
            }

            
        }

    }
}
