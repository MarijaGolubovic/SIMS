using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    public class DiagnosisStorage : IDiagnosisStorage
    {
        public DiagnosisStorage() { }
        public List<Diagnosis> GetAll()
        {
            Serialization.Serializer<Diagnosis> diagnosisSerializer = new Serialization.Serializer<Diagnosis>();
            List<Diagnosis> diagnosis = diagnosisSerializer.fromCSV("diagnosis.txt");

            return diagnosis;
        }

        public Diagnosis GetOne(int appointmentID)
        {
            Serialization.Serializer<Diagnosis> diagnosisSerializer = new Serialization.Serializer<Diagnosis>();
            List<Diagnosis> diagnosis = diagnosisSerializer.fromCSV("diagnosis.txt");
            Diagnosis dia = new Diagnosis();

            foreach (Diagnosis d in diagnosis)
            {
                if (d.AppointmentId.Equals(appointmentID))
                {
                    dia = d;
                    break;
                }
            }
            return dia;
        }

        public List<Diagnosis> GetByPatient(Patient patient)
        {
            Serialization.Serializer<Diagnosis> diagnosisSerializer = new Serialization.Serializer<Diagnosis>();
            List<Diagnosis> allDiagnosis = diagnosisSerializer.fromCSV("diagnosis.txt");
            List<Diagnosis> diagnosisForPatient = diagnosisSerializer.fromCSV("diagnosis.txt");
            foreach (Diagnosis d in allDiagnosis)
            {
                if (d.Patient.JMBGP.Equals(patient.JMBGP))
                {
                    diagnosisForPatient.Add(d);
                }
            }
            return diagnosisForPatient;
        }

        public Boolean Delete(int appointmentID)
        {
            List<Diagnosis> diagnosis = GetAll();

            foreach (Diagnosis d in diagnosis)
            {
                if (d.AppointmentId.Equals(appointmentID))
                {
                    diagnosis.Remove(d);
                    break;
                }
            }

            Serialization.Serializer<Diagnosis> diagnosisSerializer = new Serialization.Serializer<Diagnosis>();
            diagnosisSerializer.toCSV("appointments.txt", diagnosis);
            return true;

        }
        public Boolean Create(Diagnosis diagnosisForAdd)
        {
            Serialization.Serializer<Diagnosis> diagnosisSerializer = new Serialization.Serializer<Diagnosis>();
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            foreach (Diagnosis d in diagnosisSerializer.fromCSV("diagnosis.txt"))
            {
                diagnosis.Add(d);
            }
            diagnosis.Add(diagnosisForAdd);
            diagnosisSerializer.toCSV("diagnosis.txt", diagnosis);
            return true;
        }

        public Boolean Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public String fileName;
    }
}
