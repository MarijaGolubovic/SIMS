using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    class EquipmentDTO : INotifyPropertyChanged
    {
        private string _Name;
        private int _Quantity;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public EquipmentDTO(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
