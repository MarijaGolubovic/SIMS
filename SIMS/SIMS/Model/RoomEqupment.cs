using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    class RoomEqupment : Serialization.Serializable
    {

        private readonly Controller.EquipmentController equipmentController = new Controller.EquipmentController();

        public String RoomId { get; set; }
        public String IdEquipment { get; set; }
        public String Period { get; set; }



        public RoomEqupment()
        {
        }

        public RoomEqupment(string roomId, string idEquipment, string period)
        {
            RoomId = roomId;
            Period = period;
            IdEquipment = idEquipment;


        }

        List<Equpment> _RoomEquipment { get; set; }

        public string[] toCSV()
        {
            string[] csvValues = { RoomId, Period, IdEquipment };


            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values == null)
                return;
            //RoomId = values[0];
            //Period = values[1];
            //IdEquipment = values[2];




        }






    }
}
