using SIMS.Controller;
using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace SIMS.Service
{
    internal class DaysOffRequestService
    {
        private readonly DaysOffRequestStorage daysOffRequestStorage;
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
            foreach(DaysOffRequest req in GetAll())
            {
                if(req.RequestStatus.Equals(RequestStatus.onHold) || req.RequestStatus.Equals(RequestStatus.accepted))
                    doctors.Add(doctorController.GetByID(req.DoctorId));
            }
            return doctors;
        }
        public bool IsThereDoctorsWithSameSpetialization(String doctorId)
        {
            int doctorCounter = 0;
            foreach(Doctor doc in LinkDoctorsWithRequestStatusOnHoldOrAccepted(GetAll()))
            {
                if (doc.Specialization.Equals(doctorController.GetByID(doctorId).Specialization))
                    doctorCounter++;  
            }
            return doctorCounter > 1;
        }

        

        public bool IsSelectedDatesValid(DateTime startDate, DateTime endDate)
        {

            if (startDate > endDate)
                return false;
            else if (startDate.AddDays(startDate.Day + 2) >= startDate)
                return false;

            return true;
        }

        
    }
}
