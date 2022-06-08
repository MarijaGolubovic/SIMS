using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    internal class AllergyStorage : IAllergyStorage
    {
        private Serialization.Serializer<Allergy> allergySerializer;

        public AllergyStorage()
        {
            allergySerializer = new Serialization.Serializer<Allergy>();
        }

        public List<Allergy> GetAll()
        {
            List<Allergy> allergies = allergySerializer.fromCSV("medicine.txt");

            return allergies;
        }

        public Allergy GetOne(string name)
        {
            List<Allergy> allergies = GetAll();
            Allergy allergy = new Allergy();

            foreach (Allergy a in allergies)
            {
                if (a.Equals(name))
                {
                    allergy = a;
                    break;
                }
            }
            return allergy;

        }

        public Boolean Delete(int name)
        {
            throw new NotImplementedException();
        }
        public Boolean Create(Medicine medicine)
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
