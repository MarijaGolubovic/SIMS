using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
