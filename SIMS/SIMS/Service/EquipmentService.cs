using System.Collections.Generic;

namespace SIMS.Service
{
    class EquipmentService
    {
        public EquipmentService()
        {
        }
        private Repository.EquipmentStorage equipmentStorage = new Repository.EquipmentStorage();


        public List<Model.Equpment> GetAll()
        {
            return equipmentStorage.GetAll();
        }

    }
}
