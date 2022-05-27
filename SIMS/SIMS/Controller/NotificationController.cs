using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Controller
{
    public class NotificationController
    {
        private readonly PatientController patientController = new PatientController();
        public NotificationController()
        {

        }

        public void Notificate()
        {
            //dobavljam logovanog korisnika 
            Patient logedInPatient = patientController.GetOne("2212010103158");

            //dobavljam sve njegove trenutne terapije
            List<Therapy> therapiesOfPatient = logedInPatient.MedicalRecord.Therapy;

            foreach (Therapy t in therapiesOfPatient)
            {

            }

        }
    }
}
