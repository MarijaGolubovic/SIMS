using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IEquipmentStorage
    {
        public List<Model.Equpment> GetAll();
    }
}
