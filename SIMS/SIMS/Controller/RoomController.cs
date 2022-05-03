﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Service;
using SIMS.Model;

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
    }
}