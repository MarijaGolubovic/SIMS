using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class Room : INotifyPropertyChanged, Serialization.Serializable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string[] toCSV()
        {
            string[] csvValues =
                {
                Id,
                Size.ToString(),
                Type.ToString()

            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Id = values[0];
            Size = double.Parse(values[1]);
            Type = (RoomType)Enum.Parse(typeof(RoomType), values[2]);
        }

        String _Id;
        Double _size;
        RoomType _type;


        public String Id
        {

            get
            { return _Id; }

            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    OnPropertyChanged("Id");
                }
            }


        }



        public Double Size
        {
            get
            { return _size; }

            set
            {
                if (value != _size)
                {
                    _size = value;
                    OnPropertyChanged("Size");
                }
            }
        }

        public RoomType Type
        {
            get
            { return _type; }

            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }


        public Room(string id, double size, RoomType type)
        {
            Id = id;
            Size = size;
            Type = type;
        }

        public Room() { }

        public static explicit operator Room(string v)
        {
            throw new NotImplementedException();
        }

        public Boolean IsRoomForOperation()
        {
            return Type == RoomType.OPPERATING_ROOM;
        }

        public Boolean IsRoomForExamination()
        {
            return Type == RoomType.EXAMINATION_ROOM;
        }

        public Boolean IsRoomForMeeting()
        {
            return Type == RoomType.MEETING_ROOM;
        }
    }
}