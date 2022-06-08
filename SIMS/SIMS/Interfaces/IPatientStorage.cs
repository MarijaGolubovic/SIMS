using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IPatientStorage
    {
        public List<Patient> GetAll();
        public Patient GetOne(String jmbg);
        public Boolean Create(Patient patient);
        public Boolean Update(String jmbg, AccountStatus accountStatus);
        public Boolean UpdateJMBG(String jmbgOld, String jmbgNew);
        public void Update(Patient patient);
    }
}
