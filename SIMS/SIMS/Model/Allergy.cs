using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class Allergy : Serialization.Serializable
    {
        private String name;
        public String Name
        {
            get { return name; }

            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }

        }

        public Allergy(String allergy)
        {
            this.Name = allergy;
        }

        public Allergy() { }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
