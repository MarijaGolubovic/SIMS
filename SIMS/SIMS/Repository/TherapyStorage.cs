using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Repository
{
    internal class TherapyStorage
    {
        public List<Therapy> GetAll()
        {
            Serialization.Serializer<Therapy> therapySerializer = new Serialization.Serializer<Therapy>();
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
            Serialization.Serializer<Therapy> TherapySerializer = new Serialization.Serializer<Therapy>();
            List<Therapy> Therapies = new List<Therapy>();
            foreach (Therapy t in TherapySerializer.fromCSV("therapy.txt"))
            {
                Therapies.Add(t);
            }
            Therapies.Add(therapy);
            TherapySerializer.toCSV("therapy.txt", Therapies);

            return true;
            
        }

        public Boolean Update(Therapy therapy)
        {
            throw new NotImplementedException();
        }

        public String fileName;
    }
}
