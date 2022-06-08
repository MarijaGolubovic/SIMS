using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    internal class TherapyStorage : ITherapyStorage
    {
        private Serialization.Serializer<Therapy> therapySerializer;

        public TherapyStorage()
        {
            therapySerializer = new Serialization.Serializer<Therapy>();
        }
        public List<Therapy> GetAll()
        {
            List<Therapy> therapies = therapySerializer.fromCSV("therapy.txt");
            return therapies;
        }

        public List<Therapy> GetById(String id)
        {
            List<Therapy> therapies = GetAll();
            List<Therapy> therapyForDoctor = new List<Therapy>();

            foreach (Therapy t in therapies)
            {
                if (t.PatientId.Equals(id))
                {
                    therapyForDoctor.Add(t);
                }
            }
            return therapyForDoctor;

        }
        public Boolean Create(Therapy therapy)
        {
            List<Therapy> Therapies = new List<Therapy>();
            foreach (Therapy t in therapySerializer.fromCSV("therapy.txt"))
            {
                Therapies.Add(t);
            }
            Therapies.Add(therapy);
            therapySerializer.toCSV("therapy.txt", Therapies);

            return true;

        }

        public String fileName;
    }
}
