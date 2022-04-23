using SIMS.Model;
using SIMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
