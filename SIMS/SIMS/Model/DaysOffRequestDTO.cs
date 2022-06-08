using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class DaysOffRequestDTO : INotifyPropertyChanged
    {

        private string doctrorId;
        private string doctorNameSurname;
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
        public String DoctorNameSurname
        {
            get
            { return doctorNameSurname; }

            set
            {
                if (value != doctorNameSurname)
                {
                    doctorNameSurname = value;
                    OnPropertyChanged("DoctorNameSurname");
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

        public DaysOffRequestDTO(string doctorId, string doctorNameSurname, DateTime startDate, DateTime endDate, string reason, bool isUrgently, RequestStatus requestStatus, int requestId, string comment)
        {
            DoctorId = doctorId;
            DoctorNameSurname = doctorNameSurname;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            IsUrgently = isUrgently;
            RequestStatus = requestStatus;
            RequestId = requestId;
            Comment = comment;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
