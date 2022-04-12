using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class RoomStorage
    {
        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
            rooms = roomSerijalization.fromCSV("Room.csv");

            return rooms;
        }

        public Room GetOne(int roomID)
        {
            Room room = new Room();
            List<Room> rooms = new List<Room>();
            Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
            rooms = roomSerijalization.fromCSV("Room.csv");

            foreach (Room roomInput in rooms)
            {
                if (roomID.Equals(roomInput.Id))
                {
                    room = roomInput;
                }
            }

            return room;
        }

        public Boolean Delete(int roomID)
        {
            Boolean status = false;
            List<Room> rooms = new List<Room>();
            Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
            rooms = roomSerijalization.fromCSV("Room.csv");
            foreach (Room roomInput in rooms)
            {
                if (roomID.Equals(roomInput.Id))
                {
                    rooms.Remove(roomInput);
                    status = true;
                }
            }
            return status;
        }

        public Boolean Create(Room room)
        {
            Boolean status = false;
            List<Room> rooms = new List<Room>();
            Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
            rooms = roomSerijalization.fromCSV("Room.csv");
            rooms.Add(room);
            roomSerijalization.toCSV("Room.csv", rooms);
            status = true;
            return status;
        }

        public Boolean Update(Room room)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetByType(RoomType type)
        {
            List<Room> rooms = new List<Room>();
            Serialization.Serializer<Room> roomSerijalization = new Serialization.Serializer<Room>();
            rooms = roomSerijalization.fromCSV("Room.csv");
            List<Room> room = new List<Room>();
            foreach (Room inputRoom in rooms)
            {
                if (type == inputRoom.Type)
                {
                    room.Add(inputRoom);
                }
            }

            return room;
        }

        public String fileName;

    }
}