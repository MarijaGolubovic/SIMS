using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class MedicalRecordController
    {
        private readonly MedicalRecordService service;

        public MedicalRecordController()
        {
            service = new MedicalRecordService();
        }

        public List<MedicalRecord> GetAll()
        {
            return service.GetAll();
        }

        public MedicalRecord GetOne(String jmbg)
        {
            return service.GetOne(jmbg);
        }

        public void Update(Patient patient, String height, String weight, List<AllergyDTO> allergyDTOs, String bloodType)
        {
            List<Allergy> allergies = new List<Allergy>();
            foreach (AllergyDTO a in allergyDTOs)
            {
                if (a.IsSelected)
                {
                    allergies.Add(new Allergy(a.AllergyName));
                }
            }
            service.Update(patient.Person.JMBG, new MedicalRecord(Double.Parse(height), Double.Parse(weight), allergies, (BloodType)Enum.Parse(typeof(BloodType), bloodType), new List<Therapy>(), patient));
        }

    }
}
