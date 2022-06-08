using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{
    public class Supplies : INotifyPropertyChanged, Serialization.Serializable
    {

        String _Name;
        int _Quantity;
        public event PropertyChangedEventHandler PropertyChanged;
        int _NewQuantity;
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

        public int NewQuantity
        {
            get
            { return _NewQuantity; }

            set
            {
                if (value != _NewQuantity)
                {
                    _NewQuantity = value;
                    OnPropertyChanged("NewQuantity");
                }
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        public Supplies(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public Supplies()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues = {
                Name,
                Quantity.ToString(),
                NewQuantity.ToString()

            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
            Quantity = int.Parse(values[1]);
            NewQuantity = int.Parse(values[2]);
        }


    }


}
