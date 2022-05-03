using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class PatientController
    {
        private readonly PatientService patientService;
        private readonly UserService userService;
        private readonly AllergyController allergyController;
        private readonly MedicalRecordController medicalRecordController;

        public PatientController()
        {
            patientService = new PatientService();
            userService = new UserService();
            allergyController = new AllergyController();
            medicalRecordController = new MedicalRecordController();
        }

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Patient GetOne(String jmbg)
        {
            return patientService.GetOne(jmbg);
        }

        public List<Patient> GetAllActiv()
        {
            return patientService.GetAllActiv();
        }

        public List<Patient> GetAllBlock()
        {
            return patientService.GetAllBlock();
        }

        public void Update(Patient patient)
        {
            patientService.Update(patient.Person.JMBG, patient.AccountStatus);
        }

        public Boolean Create(Patient patient)
        {
            return patientService.Create(patient);
        }

        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew)
        {
            return patientService.UpdateJMBG(jmbgOld, jmbgNew);
        }

        public Patient CreateNewPatient(NewPatientDTO patientDTO)
        {
            User user = new User(patientDTO.Name + "." + patientDTO.Surname, "lozinka123", UserType.patient, new Person(patientDTO.Name, patientDTO.Surname, patientDTO.JMBG, patientDTO.PhoneNumber, patientDTO.DateTime));
            Patient patient = new Patient(user, new MedicalRecord(), new AccountStatus(true, true));
            patientService.Create(patient);
            userService.Create(user);
            return patient;
        }

        public List<AllergyDTO> GetAllergies(String jmbg)
        {
            Patient patient = GetOne(jmbg);
            List<AllergyDTO> allergies = new List<AllergyDTO>();
            foreach (Allergy a in allergyController.GetAll())
            {
                if (medicalRecordController.GetOne(jmbg) == null)
                {
                    allergies.Add(new AllergyDTO(a.allergy, false));
                }
                else
                {
                    if (medicalRecordController.GetOne(jmbg).Allergies.Find(m => m.allergy.Equals(a.allergy)) == null)
                    {
                        allergies.Add(new AllergyDTO(a.allergy, false));
                    }
                    else
                    {
                        allergies.Add(new AllergyDTO(a.allergy, true));
                    }
                }
            }
            return allergies;

        }

    }
}
