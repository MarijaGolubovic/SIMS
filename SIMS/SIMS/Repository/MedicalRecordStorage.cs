using SIMS.Controller;
using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class MedicalRecordStorage : IMedicalRecordStorage
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
                Serialization.Serializer<MedicalRecord> mrSerializer = new Serialization.Serializer<MedicalRecord>();
                List<MedicalRecord> medicalRecords = GetAll();
                medicalRecords.Remove(medicalRecords.Find(p => p.patient.Person.JMBG.Equals(jmbg)));
                medicalRecords.Add(medicalRecord);
                mrSerializer.toCSV("medicalRecords.txt", medicalRecords);
            }

            return true;
        }

        public String fileName;

    }
}