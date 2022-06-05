using SIMS.Interfaces;
using System.Collections.Generic;

namespace SIMS.Repository
{
    class EquipmentStorage: IEquipmentStorage
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
