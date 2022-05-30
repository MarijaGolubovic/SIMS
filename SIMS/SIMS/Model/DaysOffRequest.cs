using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class DaysOffRequest : Serialization.Serializable, INotifyPropertyChanged
    {
        private string doctrorId;
        private DateTime startDate;
        private DateTime endDate;
        private String reason;
        private bool isUrgently;
        private RequestStatus requestStatus;
        private int requestId;
        private String comment;

        public String DoctorId
        {
            get
            { return doctrorId; }

            set
            {
                if (value != doctrorId)
                {
                    doctrorId = value;
                    OnPropertyChanged("DoctorId");
                }
            }
        }
        public DateTime StartDate
        {
            get
            { return startDate; }

            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        public DateTime EndDate
        {
            get
            { return endDate; }

            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }
        public String Reason
        {
            get
            { return reason; }

            set
            {
                if (value != reason)
                {
                    reason = value;
                    OnPropertyChanged("Reason");
                }
            }
        }
        public bool IsUrgently
        {
            get
            { return isUrgently; }

            set
            {
                if (value != isUrgently)
                {
                    isUrgently = value;
                    OnPropertyChanged("IsUrgently");
                }
            }
        }
        public RequestStatus RequestStatus
        {
            get
            { return requestStatus; }

            set
            {
                if (value != requestStatus)
                {
                    requestStatus = value;
                    OnPropertyChanged("RequestStatus");
                }
            }
        }
        public int RequestId
        {
            get
            { return requestId; }

            set
            {
                if (value != requestId)
                {
                    requestId = value;
                    OnPropertyChanged("RequestId");
                }
            }
        }

        public String Comment
        {
            get
            { return comment; }

            set
            {
                if (value != comment)
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            Comment = "";
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
                RequestId.ToString(),
                Comment
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
            Comment = values[7];
        }

        public void AcceptRequest()
        {
            this.Comment = "";
            this.RequestStatus = RequestStatus.accepted;
        }

        public void DenyRequest()
        {
            this.RequestStatus = RequestStatus.refused;
        }

        public DaysOffRequest(string doctorId, DateTime startDate, DateTime endDate, string reason, bool isUrgently, RequestStatus requestStatus, int requestId, string comment)
        {
            DoctorId = doctorId;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsUrgently = isUrgently;
            RequestStatus = requestStatus;
            RequestId = requestId;
            Comment = comment;
        }
    }
}
