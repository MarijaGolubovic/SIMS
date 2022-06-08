using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    class OccupacyRoomStorage : IOccupacyRoomStorage
    {
        public OccupacyRoomStorage()
        {
        }

        public Boolean Delete(RoomOccupacy roomOccupacy)
        {
            List<RoomOccupacy> roomOccupacies = GetAll();

            for (int i = 0; i < roomOccupacies.Count; i++)
            {
                if (roomOccupacy.IDRoom.Equals(roomOccupacies[i].IDRoom))
                {
                    if (DateTime.Compare(roomOccupacy.Begin, roomOccupacies[i].Begin) == 0)
                    {
                        if (DateTime.Compare(roomOccupacy.End, roomOccupacies[i].End) == 0)
                        {
                            roomOccupacies.Remove(roomOccupacies[i]);
                        }
                    }
                }
            }

            Serialization.Serializer<RoomOccupacy> roomOccupacySerializer = new Serialization.Serializer<RoomOccupacy>();
            roomOccupacySerializer.toCSV("OccupacyRoom.txt", roomOccupacies);
            return true;
        }
        public List<Model.RoomOccupacy> GetAll()
        {
            Serialization.Serializer<Model.RoomOccupacy> occupacyRoomSerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> occupacy = occupacyRoomSerializer.fromCSV("OccupacyRoom.txt");

            return occupacy;
        }
        public List<Model.Room> GetById(String roomID)
        {
            Model.Room room = new Model.Room();
            List<Model.Room> findRooms = new List<Model.Room>();
            List<Model.Room> rooms = new List<Model.Room>();
            Serialization.Serializer<Model.Room> roomSerijalization = new Serialization.Serializer<Model.Room>();
            rooms = roomSerijalization.fromCSV("OccupacyRoom.txt");

            foreach (Model.Room roomInput in rooms)
            {
                if (roomID.Equals(roomInput.Id))
                {
                    room = roomInput;
                    findRooms.Add(roomInput);

                }
            }

            return findRooms;
        }


        public Model.RoomOccupacy GetOne(int appointmentID)
        {
            Serialization.Serializer<Model.RoomOccupacy> roomOccupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> roomOccupacies = roomOccupacySerializer.fromCSV("OccupacyRoom.txt");
            Model.RoomOccupacy occupacy = new Model.RoomOccupacy();

            foreach (Model.RoomOccupacy occupacyRoom in roomOccupacies)
            {
                if (occupacyRoom.IDRoom.Equals(appointmentID))
                {
                    occupacy = occupacyRoom;
                    break;
                }
            }
            return occupacy;
        }

        public Boolean Create(Model.RoomOccupacy roomOccypacy)
        {
            Serialization.Serializer<Model.RoomOccupacy> occupacySerializer = new Serialization.Serializer<Model.RoomOccupacy>();
            List<Model.RoomOccupacy> occupacies = new List<Model.RoomOccupacy>();
            foreach (Model.RoomOccupacy occ in occupacySerializer.fromCSV("OccupacyRoom.txt"))
            {
                occupacies.Add(occ);
            }
            occupacies.Add(roomOccypacy);
            occupacySerializer.toCSV("OccupacyRoom.txt", occupacies);
            return true;
        }


        public String fileName;

    }
}
