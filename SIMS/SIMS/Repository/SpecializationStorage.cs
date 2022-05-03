using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class SpecializationStorage
    {
        public List<Specialization> GetAll()
        {
            List<Specialization> specializations = new List<Specialization>();
            Serialization.Serializer<Specialization> serializer = new Serialization.Serializer<Specialization>();
            specializations = serializer.fromCSV("specializations.txt");
            return specializations;
        }

        public List<Specialization> GetAllSpecialist()
        {
            List<Specialization> specializations = new List<Specialization>();
            Serialization.Serializer<Specialization> serializer = new Serialization.Serializer<Specialization>();
            specializations = serializer.fromCSV("specializations.txt");
            foreach (Specialization s in specializations.ToArray())
            {
                if (s.Name.Equals("Opste prakse"))
                {
                    specializations.Remove(s);
                }
            }
            return specializations;
        }

        public List<Specialization> GetAllOpstePrakse()
        {
            List<Specialization> specializations = new List<Specialization>();
            Serialization.Serializer<Specialization> serializer = new Serialization.Serializer<Specialization>();
            specializations = serializer.fromCSV("specializations.txt");
            foreach (Specialization s in specializations.ToArray())
            {
                if (!s.Name.Equals("Opste prakse"))
                {
                    specializations.Remove(s);
                }
            }
            return specializations;
        }

        public Boolean Create(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public Boolean Update(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public String fileName;

    }
}