﻿using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    class RoomEquipmentServices
    {
        RoomEquipmentStorage roomEquipment = new Repository.RoomEquipmentStorage();
        EquipmentStorage equipmentStorage = new Repository.EquipmentStorage();
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


      public bool MoveEquipmentToAnatherRoom(MoveRoomEquipmentDTO moveRoomEquipment)
        {
            BeginEndTime beginEnd = ParseOccupacyPeriod(moveRoomEquipment.Begin, moveRoomEquipment.End);
            String equpmentId = FindEquipmentIdByName(equipmentStorage.GetAll(), moveRoomEquipment.Name);

            bool succesfullyMove = false;

            if (!EndBeforeBegin(beginEnd.Begin, beginEnd.End))
            {
                if (!EquipmentAlreadyOccupacy(equpmentId, beginEnd.Begin, beginEnd.End))
                {
                    String movingPeriod = beginEnd.Begin.ToString() + ";" + beginEnd.End.ToString();
                    roomEquipment.GetAll().Add(new RoomEqupment(moveRoomEquipment.RoomId, movingPeriod, equpmentId));
                    succesfullyMove = true;
                }
            }
            return succesfullyMove;
        }


        public BeginEndTime ParseOccupacyPeriod(string begin, string end)
        {
            String[] beginToken = begin.Split(';');
            DateTime beginTime = DateTime.Parse(beginToken[0]);
            String[] endToken = end.Split(';');
            DateTime endTime = DateTime.Parse(endToken[0]);
            BeginEndTime occupacyPeriod = new BeginEndTime(beginTime, endTime);

            return  occupacyPeriod;
        }

        public string FindEquipmentIdByRoom(List<Model.RoomEqupment> roomEquipments, string equpmentId)
        {
            foreach (RoomEqupment eqRoom in roomEquipments)
            {
                if (eqRoom.IdEquipment.Equals(equpmentId))
                    equpmentId = eqRoom.IdEquipment;
            }
            return equpmentId;
        }

        public string FindEquipmentIdByName(List<Model.Equpment> equipments, string equipmentName)
        {
            String equpmentId = "";
            foreach (Equpment equpmentItem in equipments)
            {
                if (equipmentName.Equals(equpmentItem.Name))
                    equpmentId = equpmentItem.Id;
            }
            return equpmentId;
        }

        public bool EquipmentAlreadyOccupacy(string idEq, DateTime begin, DateTime end)
        {
            List<Model.RoomEqupment> roomEquipments = roomEquipment.GetAll();
            Serialization.Serializer<Model.RoomEqupment> occupacySerializer = new Serialization.Serializer<Model.RoomEqupment>();
            bool Occupacy = false;

            foreach (Model.RoomEqupment roomEquipmentItem in roomEquipments)
            {
                if (roomEquipmentItem.IdEquipment.Equals(idEq))
                {
                    string[] period = roomEquipmentItem.Period.Trim().Split(';');
                    DateTime beginInStorege = DateTime.Parse(period[0]);
                    DateTime endInStorege = DateTime.Parse(period[1]);
                    Occupacy = true;
                }
            }
            return Occupacy;
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
