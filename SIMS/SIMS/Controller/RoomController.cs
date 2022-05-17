﻿using System;
using System.Collections.Generic;
using SIMS.Model;
using SIMS.Service;

namespace SIMS.Controller
{
    public class RoomController
    {
        private RoomService roomService = new RoomService();

        public RoomController()
        {
        }
        public Room GetOne(String roomID)
        {
            return roomService.GetOne(roomID);
        }

        public List<Room> GetAll()
        {
            return roomService.GetAll();
        }

        public Boolean Delete(string roomID)
        {

            return roomService.Delete(roomID);
        }

        public Boolean Create(Room room)
        {

            return roomService.Create(room);

        }

        public List<Room> GetByType(RoomType type)
        {

            return roomService.GetByType(type);

        }

    }
}
