using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SIMS.Model
{

    public class City : ValidationBase, Serialization.Serializable
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("City");
                }
            }
        }


        public City(string name)
        {
            Name = name;
        }

        public City()
        {
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
        }

        public string[] toCSV()
        {
            String[] csvValues = {
                Name
            };
            return csvValues;
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this._name))
            {
                this.ValidationErrors["City"] = "Grad ne smije biti prazan!";
            }
            else if (!Regex.IsMatch(this._name, "^[a-zA-Z_ ]*$"))
            {
                this.ValidationErrors["City"] = "Grad treba da sadrži samo slova!";
            }
        }
    }
}