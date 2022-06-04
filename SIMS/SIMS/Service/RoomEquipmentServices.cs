﻿using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    class RoomEquipmentServices
    {
        Repository.RoomEquipmentStorage roomEquipment = new Repository.RoomEquipmentStorage();
        Repository.EquipmentStorage equipmentStorage = new Repository.EquipmentStorage();
        public List<Model.RoomEqupment> GetAll()
        {
            return roomEquipment.GetAll();
        }

        public Model.RoomEqupment GetOne(String roomID)
        {
            return roomEquipment.GetOne(roomID);
        }

        public Boolean Delete(int roomID)
        {
            return roomEquipment.Delete(roomID);
        }

        public Boolean Create(Model.RoomEqupment room)
        {
            return roomEquipment.Create(room);
        }


        public bool MoveEquipmentToAnatherRoom(string Name, string roomId, string destination, string begin, string end)
        {
            Serialization.Serializer<Model.Equpment> equpmentSerializer = new Serialization.Serializer<Model.Equpment>();
            List<Model.Equpment> equipments = equpmentSerializer.fromCSV("Equipment.txt");
            List<Model.RoomEqupment> roomEquipments = roomEquipment.GetAll();
            Serialization.Serializer<Model.RoomEqupment> roomEquipmentSerializer = new Serialization.Serializer<Model.RoomEqupment>();

            String[] beginToken = begin.Split(';');
            DateTime beginTime = DateTime.Parse(beginToken[0]);
            String[] endToken = end.Split(';');
            DateTime endTime = DateTime.Parse(endToken[0]);

            String equpmentId = "";
            bool succesfullyMove = false;

            foreach (Equpment equpmentItem in equipments)
            {
                if (Name.Equals(equpmentItem.Name))
                {
                    equpmentId = equpmentItem.Id;
                }
            }
            foreach (RoomEqupment eqRoom in roomEquipments)
            {
                if (eqRoom.IdEquipment.Equals(equpmentId))
                {
                    equpmentId = eqRoom.IdEquipment;
                }
            }
            if (!EndBeforeBegin(beginTime, endTime))
            {
                if (!EquipmentAlreadyOccupacy(equpmentId, beginTime, endTime))
                {
                    String movingPeriod = beginToken[0] + ";" + endToken[0];
                    roomEquipments.Add(new RoomEqupment(roomId, movingPeriod, equpmentId));
                    // roomEquipmentSerializer.toCSV("RoomEquipment.txt", roomEquipments);
                    succesfullyMove = true;

                    /*  foreach (Equpment equpmentItem in equipments)
                      {
                          if (Name.Equals(equpmentItem.Name))
                          {

                              equpmentItem.Quantity--;
                          }
                      }
                    */
                }
            }
            else
            {
                succesfullyMove = false;
            }


            return succesfullyMove;

        }


        public bool EquipmentAlreadyOccupacy(string idEq, DateTime begin, DateTime end)
        {
            List<Model.RoomEqupment> roomEquipments = roomEquipment.GetAll();
            Serialization.Serializer<Model.RoomEqupment> occupacySerializer = new Serialization.Serializer<Model.RoomEqupment>();
            bool isOccupacy = false;

            foreach (Model.RoomEqupment roomEquipmentItem in roomEquipments)
            {
                if (roomEquipmentItem.IdEquipment.Equals(idEq))
                {
                    string[] period = roomEquipmentItem.Period.Trim().Split(';');
                    DateTime beginInStorege = DateTime.Parse(period[0]);
                    DateTime endInStorege = DateTime.Parse(period[1]);

                    //if ((DateTime.Compare(beginInStorege, begin) >= 0) && (DateTime.Compare(endInStorege, end) <= 0))
                    //if ((DateTime.Compare(beginInStorege, begin) >= 0) && (DateTime.Compare(endInStorege, end) <= 0))
                    //{
                    isOccupacy = true;
                    //}
                }
            }

            return isOccupacy;
        }

        public bool EndBeforeBegin(DateTime begin, DateTime end)
        {
            bool isEndBeforeBegin = false;
            if (DateTime.Compare(end, begin) < 0)
            {
                isEndBeforeBegin = true;
            }

            return isEndBeforeBegin;
        }


        public List<Equpment> SearchEquipment(String inputSearchContent)
        {
            List<Equpment> allEquipment = equipmentStorage.GetAll();
            List<Equpment> searchedEquipment = new List<Equpment>();
            foreach (Equpment roomEquipment in allEquipment)
            {
                if (roomEquipment.Name.Trim().Contains(inputSearchContent))
                {
                    searchedEquipment.Add(roomEquipment);
                }
            }
            return searchedEquipment;
        }
    }
}
