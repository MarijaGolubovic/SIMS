using System;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{

    public class RoomOccupacy : Serialization.Serializable
    {
        //private String _IDRoom;
        //private DateTime _Begin;
        //private DateTime _End;
        //private String _Reason;

        public String IDRoom { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Reason { get; set; }

        public void fromCSV(string[] values)
        {
            IDRoom = values[0];
            Begin = DateTime.Parse(values[1]);
            End = DateTime.Parse(values[2]);
            Reason = values[3];
        }

        public string[] toCSV()
        {
            string[] csvValues =
               {
                IDRoom,
                Begin.ToString(),
                End.ToString(),
                Reason

            };
            return csvValues;
        }

        public RoomOccupacy(string iDRoom, DateTime begin, DateTime end, string reason)
        {
            IDRoom = iDRoom;
            Begin = begin;
            End = end;
            Reason = reason;
        }

        public RoomOccupacy()
        {
        }
    }
}
