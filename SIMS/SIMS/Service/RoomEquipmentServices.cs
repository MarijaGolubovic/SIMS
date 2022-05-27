using System;
using System.Collections.Generic;
using SIMS.Model;

namespace SIMS.Service
{
    class RoomEquipmentServices
    {
        Repository.RoomEquipmentStorage roomEquipment = new Repository.RoomEquipmentStorage();

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

        public String MovingRoomEqupment(Model.Room roomBegin, Model.Room roomEnd, List<Model.Equpment> equpments, String period, int quanitity)
        {
            List<Model.RoomEqupment> roomEqupmentsList = new List<Model.RoomEqupment>();
            roomEqupmentsList = roomEquipment.GetAll();
            String[] tokens = period.Split('-');
            DateTime begin = DateTime.Parse(tokens[0]);
            DateTime end = DateTime.Parse(tokens[1]);

            Serialization.Serializer<Model.RoomEqupment> roomSerijalization = new Serialization.Serializer<Model.RoomEqupment>();

            foreach (Model.RoomEqupment roomE in roomEqupmentsList)
            {
                if (roomE.RoomId.Equals(roomBegin.Id))
                {
                    String time = roomE.Period;
                    String[] token = time.Split('-');
                    DateTime beginTime = DateTime.Parse(token[0]);
                    DateTime endTime = DateTime.Parse(token[1]);
                    if (DateTime.Compare(begin, beginTime) <= 0 && DateTime.Compare(endTime, end) <= 0)
                    {
                        return "Equpment alredy reservet in this period";
                    }
                    else if (DateTime.Compare(end, begin) < 0)
                    {
                        return "Begin period must bi less than end ";
                    }
                    else
                    {

                        roomEqupmentsList.Add(new Model.RoomEqupment(roomEnd.Id, equpments, period));
                        roomSerijalization.toCSV("RoomEquipment.txt", roomEqupmentsList);
                        return "Equpment successfully moved";

                        if (roomBegin.Id.Equals(roomE.RoomId))
                        {



                            foreach (Model.Equpment eq in equpments)
                            {
                                if (eq.Quantity < quanitity)
                                {
                                    return "Doesn't have enough eqvipment in this sale!";
                                }
                                else
                                {

                                    roomE.roomEquipment.Remove(eq);
                                    eq.Quantity -= quanitity;

                                }
                            }
                        }
                        else if (roomEnd.Id.Equals(roomE.RoomId))
                        {
                            foreach (Model.Equpment eq in equpments)
                            {
                                roomE.roomEquipment.Remove(eq);
                                eq.Quantity += quanitity;


                            }
                        }
                    }

                }
            }


            return "";
        }

        internal string MovingRoomEqupment(Room roomItem, Room roomItemSelected, List<RoomEqupment> rommEq, string period)
        {
            throw new NotImplementedException();
        }
    }
}
