using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    class EquipmentService
    {
        public EquipmentService()
        {
        }
        private IEquipmentStorage equipmentStorage = new Repository.EquipmentStorage();


        public List<Model.Equpment> GetAll()
        {
            return equipmentStorage.GetAll();
        }

    }
}
