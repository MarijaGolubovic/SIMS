using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    class EquipmentStorage : IEquipmentStorage
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
