using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    class EquipmentService
    {
        public EquipmentService()
        {
        }
        private Repository.EquipmentStorage equipmentStorage = new Repository.EquipmentStorage();


        public List<Model.Equpment> GetAll() {
            return equipmentStorage.GetAll();
        }

    }
}
