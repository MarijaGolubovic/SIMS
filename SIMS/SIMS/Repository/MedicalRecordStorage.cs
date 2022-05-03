using System;
using System.Collections.Generic;
using SIMS.Controller;

namespace SIMS.Model
{
    public class MedicalRecordStorage
    {
        public List<MedicalRecord> GetAll()
        {
            Serialization.Serializer<MedicalRecord> medicalRecordSerializer = new Serialization.Serializer<MedicalRecord>();
            List<MedicalRecord> medicalRecords = medicalRecordSerializer.fromCSV("medicalRecords.txt");
            PatientController patientController = new PatientController();

            foreach (MedicalRecord mr in medicalRecords)
            {
                foreach (Patient itemP in patientController.GetAll())
                {
                    if (itemP.Person.JMBG.Equals(mr.patient.Person.JMBG))
                    {
                        itemP.MedicalRecord = mr;
                    }
                }
            }


            return medicalRecords;
        }

        public MedicalRecord GetOne(String jmbg)
        {
            List<MedicalRecord> medicalRecords = GetAll();
            MedicalRecord medicalRecord = new MedicalRecord();
            medicalRecord = null;
            foreach (MedicalRecord mr in medicalRecords)
            {
                if (mr.patient.Person.JMBG.Equals(jmbg))
                {
                    medicalRecord = mr;
                    break;
                }
            }
            return medicalRecord;
        }

        public Boolean Delete(String jmbg)
        {
            throw new NotImplementedException();
        }

        public Boolean Create(MedicalRecord medicalRecord)
        {
            Serialization.Serializer<MedicalRecord> mrSerializer = new Serialization.Serializer<MedicalRecord>();
            List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
            foreach (MedicalRecord m in mrSerializer.fromCSV("medicalRecords.txt"))
            {
                medicalRecords.Add(m);
            }
            medicalRecords.Add(medicalRecord);
            mrSerializer.toCSV("medicalRecords.txt", medicalRecords);
            return true;
        }

        public Boolean Update(String jmbg, MedicalRecord medicalRecord)
        {
            if (GetOne(jmbg) == null)
            {
                Create(medicalRecord);
            }
            else
            {
                GetOne(jmbg).BloodType = medicalRecord.BloodType;
                GetOne(jmbg).Height = medicalRecord.Height;
                GetOne(jmbg).Weight = medicalRecord.Weight;
                GetOne(jmbg).Allergies = medicalRecord.Allergies;
                return true;
            }
            return true;
        }

        public String fileName;

    }
}