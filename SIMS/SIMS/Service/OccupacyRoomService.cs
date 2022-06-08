using System;
using System.Collections.Generic;
using SIMS.Controller;
using SIMS.Interfaces;
using SIMS.Model;

namespace SIMS.Service
{
    class OccupacyRoomService
    {
        private IOccupacyRoomStorage occupacyRoomStorage = new Repository.OccupacyRoomStorage();

        public String RenovateRoom(Model.Room room, DateTime begin, DateTime end, String reason)
        {
            List<Model.RoomOccupacy> roomOccupacies = occupacyRoomStorage.GetAll();
            Serialization.Serializer<Model.RoomOccupacy> occupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            String returnMessage = "";
            foreach (Model.RoomOccupacy roomItem in roomOccupacies)
            {
                if (roomItem.IDRoom.Equals(room.Id))
                {
                    if (isOccupacy(begin, roomItem.Begin, end, roomItem.End))
                        returnMessage = "Room reserved in that period";
                    else if (DateTime.Compare(end, begin) < 0)
                        returnMessage = "End period must be less than begin";
                    else
                    {
                        roomOccupacies.Add(new Model.RoomOccupacy(room.Id, begin, end, reason));
                        occupacySerializer.toCSV("OccupacyRoom.txt", roomOccupacies);
                        returnMessage = "Room succesfully added to renovation list ";
                    }

                }
            }
            return returnMessage;
        }

        public bool RoomAlreadyOccupacy(Model.Room room, DateTime begin, DateTime end, String reason)
        {
            List<Model.RoomOccupacy> roomOccupacies = occupacyRoomStorage.GetAll();
            bool occupacy = false;

            foreach (Model.RoomOccupacy roomItem in roomOccupacies)
            {
                if (roomItem.IDRoom.Equals(room.Id))
                {
                    if(isOccupacy(begin, roomItem.Begin,end,roomItem.End))
                    {
                        occupacy = true;
                    }
                }
            }
            return occupacy;
        }

        public bool isOccupacy(DateTime begin,DateTime occupacyBegin, DateTime end, DateTime occupacyEnd)
        {
            return (DateTime.Compare(occupacyBegin, begin) >= 0) && (DateTime.Compare(end,  occupacyBegin) <= 0);
        }

        //Ova funkcija je ista kao RoomAlreadyOccupacy ali kompaktnija
        public bool IfRoomIsOccupied(RoomOccupacy roomOccupacy)
        {
            List<RoomOccupacy> allRoomOccupacies = GetAll();
            foreach (RoomOccupacy ro in allRoomOccupacies)
            {
                if (IfRoomOccupaciesEqual(roomOccupacy, ro))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IfRoomOccupaciesEqual(RoomOccupacy r1, RoomOccupacy r2)
        {
            if (r1.IDRoom == r2.IDRoom)
            {
                if ((DateTime.Compare(r1.Begin, r2.Begin) <= 0) && (DateTime.Compare(r2.End, r1.End) <= 0))
                {
                    return true;
                }
            }
            return false;
        }

        public bool EndBeforeBegin( DateTime begin, DateTime end)
        {
            bool isEndBeforeBegin = false;
            if (DateTime.Compare(end, begin) < 0)
            {
                isEndBeforeBegin = true;
            }

            return isEndBeforeBegin;
        }

        public List<Model.Room> GetById(String roomID)
        {
            return occupacyRoomStorage.GetById(roomID);
        }

        public List<RoomOccupacy> GetAll()
        {
            return occupacyRoomStorage.GetAll();
        }

        public bool Create(RoomOccupacy roomOccupacy)
        {
            return occupacyRoomStorage.Create(roomOccupacy);
        }

        public Boolean Delete(RoomOccupacy roomOccupacy)
        {
            return occupacyRoomStorage.Delete(roomOccupacy);
        }

        public OccupacyRoomService()
        {
        }
    }

}
