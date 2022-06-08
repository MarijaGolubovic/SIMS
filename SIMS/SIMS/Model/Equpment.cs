using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{

    public class Equpment : INotifyPropertyChanged, Serialization.Serializable
    {
        public String Name
        {
            get
            { return _Name; }

            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

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


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int Quantity
        {
            get
            { return _Quantity; }

            set
            {
                if (value != _Quantity)
                {
                    _Quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }


        public Equpment(string name, int quantity, string id)
        {
            Name = name;
            Quantity = quantity;
            Id = id;
        }

        public Equpment()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues = {
                Name,
                Quantity.ToString(),
                Id

            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
            Quantity = int.Parse(values[1]);
            Id = values[2];
        }

        String _Name;
        int _Quantity;
        String _Id;


    }
}
