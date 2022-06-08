using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
