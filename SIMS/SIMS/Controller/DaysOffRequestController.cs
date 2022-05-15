using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    internal class DaysOffRequestController
    {
        private DaysOffRequestService daysOffRequestService;
        public DaysOffRequestController()
        {
            daysOffRequestService = new DaysOffRequestService();
        }

        public List<DaysOffRequest> GetAll()
        {
            return daysOffRequestService.GetAll();
        }

        public DaysOffRequest GetOne(int requestId)
        {
            return daysOffRequestService.GetOne(requestId);
        }
        public void Create(DaysOffRequest request)
        {
            daysOffRequestService.Create(request);
        }
        public bool IsThereDoctorsWithSameSpetialization(String doctorId)
        {
            return daysOffRequestService.IsThereDoctorsWithSameSpetialization(doctorId);
        }
        public bool IsSelectedDatesValid(DateTime startDate, DateTime endDate)
        {
            return daysOffRequestService.IsSelectedDatesValid(startDate, endDate);
        }
    }

}
