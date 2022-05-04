using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    class Equpment: INotifyPropertyChanged, Serialization.Serializable
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

        public Equpment(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public Equpment()
        {
        }

        public string[] toCSV()
        {
            string[] csvValues = {
                Name,
                Quantity.ToString()

            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
            Quantity = int.Parse(values[1]);
        }

        String _Name;
        int _Quantity;

        public static explicit operator Equpment(string v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Equpment(List<Equpment> v)
        {
            throw new NotImplementedException();
        }
    }
}
