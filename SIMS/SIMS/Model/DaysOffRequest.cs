using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    internal class DaysOffRequest : Serialization.Serializable
    {
        public String DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Reason { get; set; }
        public bool IsUrgently { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int RequestId { get; set; }
        public DaysOffRequest() { }
        public DaysOffRequest(DateTime startDate, DateTime endDate, string reason, bool isUrgently)
        {
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsUrgently = isUrgently;
            RequestStatus = RequestStatus.onHold;
            Random rnd = new Random();
            RequestId = rnd.Next(1, 100000000);
            DoctorId = ViewModel.Doctor.MainWindowViewModel.LoggedInUser.Person.JMBG;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                DoctorId,
                StartDate.ToString(),
                EndDate.ToString(),
                Reason,
                IsUrgently.ToString(),
                RequestStatus.ToString(),
                RequestId.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            DoctorId = values[0];
            StartDate = DateTime.Parse(values[1]);
            EndDate = DateTime.Parse(values[2]);
            Reason = values[3];
            IsUrgently = bool.Parse(values[4]);
            RequestStatus = (RequestStatus)Enum.Parse(typeof(RequestStatus), values[5]);
            RequestId = int.Parse(values[6]);
        }
    }
}
