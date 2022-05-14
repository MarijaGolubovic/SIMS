using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    class EquipmentStorage
    {

        public List<Model.Equpment> GetAll()
        {
            List<Model.Equpment> equipment = new List<Model.Equpment>();
            Serialization.Serializer<Model.Equpment> equipmentSerijalization = new Serialization.Serializer<Model.Equpment>();
            equipment = equipmentSerijalization.fromCSV("Equipment.txt");

            return equipment;
        }
    }
}
