using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Service
{
    public class RoomService
    {
        private RoomStorage roomStorage = new RoomStorage();

        public RoomService()
        {
        }

        public Room GetOne(String roomID)
        {
            return roomStorage.GetOne(roomID);
        }

        public List<Room> GetAll()
        {
            return roomStorage.GetAll();
        }


        public Boolean Delete(string roomID)
        {

            return roomStorage.Delete(roomID);
        }

        public Boolean Create(Room room)
        {

            return roomStorage.Create(room);

        }

        public Model.Room GetRoomById(string idRoom)
        {
            return roomStorage.GetRoomById(idRoom);
        }

        public List<Room> GetByType(RoomType type)
        {


            return roomStorage.GetByType(type);

        }

        public bool isSplitRoom(Room oldRoom, Room firtsNewRoom, Room secondNewRoom)
        {
            bool isRoomSplited = false;
            bool isFirstAdded = IsNewRoomAdd(firtsNewRoom);
            bool isSecondAdded = IsNewRoomAdd(secondNewRoom);

            if (isFirstAdded && isSecondAdded)
            {
                roomStorage.Delete(oldRoom.Id);
                isRoomSplited = true;

            }

            return isRoomSplited;
        }

        public bool IsRoomAlreadyExist(Room newRoom)
        {
            bool isExist = false;
            List<Room> allRooms = roomStorage.GetAll();
            foreach (Room existedRoom in allRooms)
            {
                if (existedRoom.Id.Equals(newRoom.Id))
                    isExist = true;
            }
            return isExist;
        }


        public bool IsNewRoomAdd(Room newRoom)
        {

            bool isAdded = false;
            if (!IsRoomAlreadyExist(newRoom))
            {
                roomStorage.Create(newRoom);
                isAdded = true;
            }
            return isAdded;
        }


        public bool IsRoomMerge(Room oldRoom, Room otherMergedRoom, Room newRoom)
        {
            bool isRoomMerged = false;
            if (!IsRoomAlreadyExist(newRoom))
            {
                if (IsRoomAlreadyExist(otherMergedRoom))
                {
                    roomStorage.Delete(oldRoom.Id);
                    roomStorage.Create(newRoom);
                    roomStorage.Delete(otherMergedRoom.Id);
                    isRoomMerged = true;
                }
            }
            return isRoomMerged;
        }

    }
}
