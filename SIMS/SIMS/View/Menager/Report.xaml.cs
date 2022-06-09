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
        public Report()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Model.Report> allReport = new List<Model.Report>();
            ReportData = new ObservableCollection<Model.Report>();

            Model.Report r1 = new Model.Report("op1", "operacija", "Dejan");
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            allReport.Add(r1);

            foreach (Model.Report report in allReport)
            {
                ReportData.Add(report);
            }

            
        }

        private void calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            //calendar.DisplayDate = DateTime.Now;
        }
    }
}
