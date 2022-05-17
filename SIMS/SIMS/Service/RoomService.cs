using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Repository;

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

        public List<Room> GetAll() {
            return roomStorage.GetAll();
        }

        public Boolean Delete(string roomID) {

            return roomStorage.Delete(roomID);
        }

        public Boolean Create(Room room) {

            return roomStorage.Create(room);
        
        }

        public List<Room> GetByType(RoomType type) {

            return roomStorage.GetByType(type);

        }

        public bool isSplitRoom(Room oldRoom, Room firtsNewRoom, Room secondNewRoom) 
        {
            bool isRoomSplited = false;
            bool isFirstAdded = isNewRoomAdd(firtsNewRoom);
            bool isSecondAdded = isNewRoomAdd(secondNewRoom);
            
            if (isFirstAdded && isSecondAdded)
            {
                roomStorage.Delete(oldRoom.Id);    
                isRoomSplited = true;
                
            }

            return isRoomSplited;
        }

        public bool isroomAlreadyExist(Room newRoom)
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


        public bool isNewRoomAdd(Room newRoom) {

            bool isAdded = false;
            if (!isroomAlreadyExist(newRoom))
            {
                roomStorage.Create(newRoom);
                isAdded = true;
            }
            return isAdded;
        }

    }
}
