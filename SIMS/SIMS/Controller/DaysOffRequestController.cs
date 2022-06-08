using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    internal class DaysOffRequestController
    {
        private DaysOffRequestService daysOffRequestService;
        private UserService userService;
        public DaysOffRequestController()
        {
            daysOffRequestService = new DaysOffRequestService();
            userService = new UserService();
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
        public bool IsThereDoctorsWithSameSpetialization(DaysOffRequest request, String doctorId)
        {
            return daysOffRequestService.IsThereDoctorsWithSameSpetialization(request, doctorId);
        }
        public bool IsSelectedDatesValid(DateTime startDate, DateTime endDate)
        {
            return daysOffRequestService.IsSelectedDatesValid(startDate, endDate);
        }

        public List<DaysOffRequestDTO> GetAllDTO()
        {
            List<DaysOffRequest> daysOffRequests = daysOffRequestService.GetAll();
            List<DaysOffRequestDTO> daysOffRequestDTOs = new List<DaysOffRequestDTO>();

            foreach (DaysOffRequest d in daysOffRequests)
            {
                daysOffRequestDTOs.Add(new DaysOffRequestDTO(d.DoctorId, userService.GetOne(d.DoctorId).Person.Name + " " + userService.GetOne(d.DoctorId).Person.Surname, d.StartDate, d.EndDate, d.Reason, d.IsUrgently, d.RequestStatus, d.RequestId, d.Comment));
            }

            return daysOffRequestDTOs;

        }

        public void AcceptRequest(DaysOffRequestDTO daysOffRequestDTO)
        {
            daysOffRequestService.AcceptRequest(new DaysOffRequest(daysOffRequestDTO.DoctorId, daysOffRequestDTO.StartDate, daysOffRequestDTO.EndDate, daysOffRequestDTO.Reason, daysOffRequestDTO.IsUrgently, daysOffRequestDTO.RequestStatus, daysOffRequestDTO.RequestId, daysOffRequestDTO.Comment));
        }

        public void DenyRequest(DaysOffRequestDTO daysOffRequestDTO)
        {
            daysOffRequestService.DenyRequest(new DaysOffRequest(daysOffRequestDTO.DoctorId, daysOffRequestDTO.StartDate, daysOffRequestDTO.EndDate, daysOffRequestDTO.Reason, daysOffRequestDTO.IsUrgently, daysOffRequestDTO.RequestStatus, daysOffRequestDTO.RequestId, daysOffRequestDTO.Comment));
        }


        public List<DaysOffRequest> GetAllRequirementsForDoctor()
        {
            return daysOffRequestService.GetAllRequirementsForDoctor();
        }

    }

}
