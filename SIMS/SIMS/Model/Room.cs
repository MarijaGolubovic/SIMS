using System;

namespace SIMS.Model
{
   public class Room
   {
      public int Id { get; set; }
      public RoomType Type { get; set; }
      public Double Size { get; set; }

      public Room(int id, RoomType type, double size)
        {
            Id = id;
            Type = type;
            Size = size;
        }
    }
}