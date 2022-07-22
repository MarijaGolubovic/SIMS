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


            //allReport.Add(new Model.Report("op1", "operacija", "Dejan"));
            // allReport.Add(new Model.Report("op1", "operacija srca", "Dejan"));
            ReportData.Add(new Model.Report("op", "pregled", "Danijela","12:15-13:00"));
            ReportData.Add(new Model.Report("sala2", "pregled", "Dejan", "8:00-9:00"));
            ReportData.Add(new Model.Report("sala2", "krecenje", "-","all day"));
            ReportData.Add(new Model.Report("magacin1", "renoviranje", "radovi.doo","all day"));


            this.DataContext = this;
            foreach (Model.Report report in allReport)
            {
                ReportData.Add(report);
            }

            
        }

        private void calendar_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DateTime dateNew1 = new DateTime(2022, 6, 12);
            DateTime dateNew2 = new DateTime(2022, 6, 20);
            DateTime dateNew3 = new DateTime(2022, 7, 10);
            DateTime dateNew4 = new DateTime(2022, 6, 15);
            if ( DateTime.Compare( calendar.SelectedDate.Value, dateNew1 ) < 0)
            {
                ReportData.Clear();
                ReportData.Add(new Model.Report("op1", "krecenje", "-", "all day"));
                ReportData.Add(new Model.Report("magacin1", "renoviranje", "radovi.doo", "all day"));
            }
            else if(DateTime.Compare(calendar.SelectedDate.Value, dateNew2) == 0)
            {
                ReportData.Clear();
                ReportData.Add(new Model.Report("sala3", "operacija srca", "Danijela", "10:00-17:00"));
                ReportData.Add(new Model.Report("sala2", "operacija", "Tamara", "9:15-15:00"));
                ReportData.Add(new Model.Report("sala5", "krecenje", "-","all day"));
                ReportData.Add(new Model.Report("magacin1", "renoviranje", "radovi.doo", "all day"));
            }else if (DateTime.Compare(calendar.SelectedDate.Value, dateNew4) == 0)
            {
                ReportData.Clear();
                ReportData.Add(new Model.Report("op", "pregled", "Danijela","10:00-10:45"));
                ReportData.Add(new Model.Report("sala2", "pregled", "Dejan", "12:30-13:00"));
                ReportData.Add(new Model.Report("sala2", "krecenje", "-", "all day"));
                ReportData.Add(new Model.Report("magacin1", "renoviranje", "radovi.doo", "all day"));
            }
            else if(DateTime.Compare(calendar.SelectedDate.Value, dateNew4) > 0 && DateTime.Compare(calendar.SelectedDate.Value, new DateTime(2022, 7, 15) ) < 0)
            {
                ReportData.Clear();
                ReportData.Add(new Model.Report("sala2", "krecenje", "-", "all day"));
                ReportData.Add(new Model.Report("magacin1", "renoviranje", "radovi.doo", "all day"));
                ReportData.Add(new Model.Report("soba12", "pregled", "Tamara", "8:15-9:00"));
            }else
            {
                ReportData.Clear();
                ReportData.Add(new Model.Report("No", "scheduled", "activity","today!"));
            }
        }
    }
}
