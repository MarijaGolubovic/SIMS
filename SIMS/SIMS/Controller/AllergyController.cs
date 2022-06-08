using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class AllergyController
    {
        private AllergyService allergyService;

        public AllergyController()
        {
            allergyService = new AllergyService();
        }

        public List<Allergy> GetAll()
        {
            return allergyService.GetAll();
        }

        public Allergy GetOne(string name)
        {
            return allergyService.GetOne(name);

        }
    }
}
