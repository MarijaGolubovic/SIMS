using SIMS.Interfaces;
using System.Collections.Generic;

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
