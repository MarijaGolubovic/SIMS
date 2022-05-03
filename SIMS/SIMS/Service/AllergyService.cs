using SIMS.Model;
using SIMS.Repository;
using System.Collections.Generic;

namespace SIMS.Service
{
    public class AllergyService
    {
        private AllergyStorage allergyStorage;

        public AllergyService()
        {
            allergyStorage = new AllergyStorage();
        }

        public List<Allergy> GetAll()
        {
            return allergyStorage.GetAll();
        }

        public Allergy GetOne(string name)
        {
            return allergyStorage.GetOne(name);

        }
    }
}
