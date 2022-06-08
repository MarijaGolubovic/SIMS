using SIMS.Controller;
using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.ViewModel.Doctor;
using System;
using System.Collections.Generic;

namespace SIMS.Service
{
    internal class DaysOffRequestService
    {
        private readonly IDaysOffRequestStorage daysOffRequestStorage;
        private readonly DoctorController doctorController;
        public DaysOffRequestService()
        {
            daysOffRequestStorage = new DaysOffRequestStorage();
            doctorController = new DoctorController();
        }

        public List<DaysOffRequest> GetAll()
        {
            return daysOffRequestStorage.GetAll();
        }

        public DaysOffRequest GetOne(int requestId)
        {
            return daysOffRequestStorage.GetOne(requestId);
        }

        public void Create(DaysOffRequest request)
        {
            daysOffRequestStorage.Create(request);
        }

        public List<SIMS.Model.Doctor> LinkDoctorsWithRequestStatusOnHoldOrAccepted(List<DaysOffRequest> requirements)
        {
            List<SIMS.Model.Doctor> doctors = new List<SIMS.Model.Doctor>();
            foreach (DaysOffRequest req in GetAll())
            {
                if (req.RequestStatus.Equals(RequestStatus.onHold) || req.RequestStatus.Equals(RequestStatus.accepted))
                    doctors.Add(doctorController.GetByID(req.DoctorId));
            }
            return doctors;
        }
        public DaysOffRequest GetRequestByDoctorId(String id)
        {
            DaysOffRequest request = new DaysOffRequest();
            foreach (DaysOffRequest req in GetAll())
            {
                if (req.DoctorId.Equals(id))
                {
                    request = req;
                    break;
                }
            }
            return request;
        }
        public bool IsThereDoctorsWithSameSpetialization(DaysOffRequest request, String doctorId)
        {
            int doctorCounter = 0;
            String specializationName = doctorController.GetByID(doctorId).Specialization.Name;
            foreach (Doctor doc in LinkDoctorsWithRequestStatusOnHoldOrAccepted(GetAll()))
            {
                if (doc.Specialization.Name.Equals(specializationName))
                    if (request.DatesOverlap(GetRequestByDoctorId(doc.Person.JMBG)))
                        doctorCounter++;
            }
            return doctorCounter > 1;
        }



        public bool IsSelectedDatesValid(DateTime startDate, DateTime endDate)
        {

            if (startDate > endDate)
                return false;
            else if (startDate < DateTime.Now.AddDays(2))
                return false;

            return true;
        }

        public void AcceptRequest(DaysOffRequest daysOffRequest)
        {
            daysOffRequest.AcceptRequest();
            daysOffRequestStorage.Update(daysOffRequest);

        }

        public void DenyRequest(DaysOffRequest daysOffRequest)
        {
            daysOffRequestStorage.Update(daysOffRequest);
        }


        public List<DaysOffRequest> GetAllRequirementsForDoctor()
        {
            List<DaysOffRequest> requirements = new List<DaysOffRequest>();

            foreach (DaysOffRequest req in GetAll())
            {
                if (req.DoctorId.Equals(MainWindowViewModel.LoggedInUser.Person.JMBG) && req.StartDate > DateTime.Now)
                {
                    requirements.Add(req);
                }
            }

            return requirements;
        }

    }
}
