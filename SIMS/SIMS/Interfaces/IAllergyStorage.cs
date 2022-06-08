using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IAllergyStorage
    {
        public List<Allergy> GetAll();
        public Allergy GetOne(string name);
        public Boolean Delete(int name);
        public Boolean Create(Medicine medicine);
        public Boolean Update(Medicine medicine);

    }
}
