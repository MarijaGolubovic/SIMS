using System.Collections.Generic;
using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;


namespace SIMS.Service
{
    public class AllergyService
    {
        private IAllergyStorage allergyStorage;

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
