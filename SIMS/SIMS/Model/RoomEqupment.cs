﻿using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    class RoomEqupment : Serialization.Serializable
    {

        private readonly Controller.EquipmentController equipmentController = new Controller.EquipmentController();

        public String RoomId { get; set; }
        public List<Equpment> roomEquipment { get; set; }
        public String Period { get; set; }

        String _RoomId;

        public RoomEqupment()
        {
        }

        public RoomEqupment(string roomId, List<Equpment> roomEquipment, string period)
        {
            RoomId = roomId;
            this.roomEquipment = roomEquipment;
            Period = period;
        }

        List<Equpment> _RoomEquipment { get; set; }

        public string[] toCSV()
        {
            string[] csvValues = { RoomId, Period };
            int i = 2;
            foreach (Equpment equipment in roomEquipment)
            {
                csvValues[i] = equipment.ToString();
                i++;
            }
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            RoomId = values[0];
            Period = values[1];

            if (values == null)
                return;

            int i;
            for (i = 2; i < values.Length; i++)
            {
                roomEquipment.Add((Equpment)values[i]);
            }

        }






    }
}
