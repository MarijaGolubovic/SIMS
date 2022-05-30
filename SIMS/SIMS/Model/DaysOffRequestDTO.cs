using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class DaysOffRequestDTO
    {
        public String DoctorId { get; set; }
        public String DoctorNameSurname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Reason { get; set; }
        public bool IsUrgently { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public int RequestId { get; set; }

        public String Comment { get; set; }

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
    }
}
