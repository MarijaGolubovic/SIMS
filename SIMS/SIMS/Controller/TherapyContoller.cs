using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;



namespace SIMS.Controller
{
    internal class TherapyContoller
    {
        private TherapyService therapyService;
        private readonly PatientController patientController = new PatientController();
        private NotificationStorage notificationStorage = new NotificationStorage();

        public TherapyContoller()
        {
            therapyService = new TherapyService();
        }

        public List<Therapy> GetAll()
        {
            return therapyService.GetAll();
        }

        public List<Therapy> GetById(string id)
        {
            return therapyService.GetById(id);
        }

        public Boolean Create(Therapy therapy)
        {
            /*
            //ovaj kod trebam negdje lijepo smjestiti

            //ovdje treba zamijeniti datumom kad je terapija propisana
            DateTime start = new DateTime(therapy.timeOfMaking.Year, therapy.timeOfMaking.Month, therapy.timeOfMaking.Day, 0, 0, 0);

            //ovdje treba zamijeniti staticki podatak tranjem terapije
            DateTime end = start.AddDays(int.Parse(therapy.PeriodInDays));
            int addingHours = 24 / int.Parse(therapy.PeriodInHours);

            for (int i = 0; i < int.Parse(therapy.PeriodInDays); ++i)
            {
                for (int j = 0; j < int.Parse(therapy.PeriodInHours); ++j)
                {
                    DateTime dateTimeTmp = start.AddDays(i).AddHours(j * addingHours);
                    String details = "Popiti lek " + therapy.Medicine.Name + " u " + dateTimeTmp.ToString();
                    Patient patient = patientController.GetOne(therapy.PatientId);
                    Notificatoin notification = new Notificatoin(dateTimeTmp, details, patient);
                    patient.NotificationList.Add(notification);
                    notificationStorage.Create(notification);
                }
            }*/
            return therapyService.Create(therapy);
        }
    }
}
