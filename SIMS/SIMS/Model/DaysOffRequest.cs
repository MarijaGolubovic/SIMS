using SIMS.ViewModel.Doctor;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

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
        public String Name { get; set; }
        public String StartDateForDoctor { get; set; }
        public String EndDateForDoctor { get; set; }

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
            Name = "Slobodan dan";
            StartDateForDoctor = StartDate.ToString().Split(' ')[0];
            EndDateForDoctor = EndDate.ToString().Split(' ')[0];
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

        public Boolean DatesOverlap(DaysOffRequest req)
        {
            return (this.StartDate >= req.StartDate && this.EndDate <= req.EndDate)
                            || (this.StartDate <= req.StartDate && this.EndDate <= req.EndDate && this.EndDate >= req.StartDate)
                                || (this.StartDate >= req.StartDate && this.StartDate <= req.EndDate && this.EndDate >= req.EndDate)
                                    || (this.StartDate <= req.StartDate && this.EndDate >= req.EndDate);
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
            Name = "Slobodan dan";
            StartDateForDoctor = startDate.ToString().Split(' ')[0];
            EndDateForDoctor = endDate.ToString().Split(' ')[0];
        }
        public DaysOffRequest(DateTime startDate, DateTime endDate, string reason, bool isUrgently)
        {
            DoctorId = MainWindowViewModel.LoggedInUser.Person.JMBG;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsUrgently = isUrgently;
            RequestStatus = requestStatus;
            var random = new Random();
            RequestId = random.Next();
            Comment = "";
            Name = "Slobodan dan";
            StartDateForDoctor = startDate.ToString().Split(' ')[0];
            EndDateForDoctor = endDate.ToString().Split(' ')[0];
        }
    }
}
