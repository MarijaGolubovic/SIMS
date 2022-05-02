using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class MedicalRecordStorage
    {
        public List<MedicalRecord> GetAll()
        {
            Serialization.Serializer<MedicalRecord> medicalRecordSerializer = new Serialization.Serializer<MedicalRecord>();
            List<MedicalRecord> medicalRecords = medicalRecordSerializer.fromCSV("medicalRecords.txt");

            return medicalRecords;
        }

        public MedicalRecord GetOne(String jmbg)
        {
            List<MedicalRecord> medicalRecords = GetAll();
            MedicalRecord medicalRecord = new MedicalRecord();
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
            throw new NotImplementedException();
        }

        public Boolean Update(MedicalRecord medicalRecord)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}