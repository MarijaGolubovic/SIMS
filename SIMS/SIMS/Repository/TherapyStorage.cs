using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Boolean Create(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public String fileName;
    }
}
