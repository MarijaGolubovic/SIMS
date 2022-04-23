using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    internal class AllergyStorage
    {
        public AllergyStorage() { }

        public List<Allergy> GetAll()
        {
            Serialization.Serializer<Allergy> allergySerializer = new Serialization.Serializer<Allergy>();
            List<Allergy> allergies = allergySerializer.fromCSV("medicine.txt");

            return allergies;
        }

        public Allergy GetOne(string name)
        {
            List<Allergy> allergies = GetAll();
            Allergy allergy = new Allergy();

            foreach(Allergy a in allergies)
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
