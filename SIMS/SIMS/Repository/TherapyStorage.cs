using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Repository
{
    internal class TherapyStorage
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

        public Boolean Delete(int name)
        {
            throw new NotImplementedException();
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

        public Boolean Update(Therapy therapy)
        {
            throw new NotImplementedException();
        }

        public String fileName;
    }
}
