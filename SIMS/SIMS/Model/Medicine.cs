using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Model
{
    public class Medicine : INotifyPropertyChanged, Serialization.Serializable
    {
        private string _Name;
        private MedicineStatus _MedicineStatus;
        public int _Quantity;
        public List<String> _Ingredients;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {

                if (value != _Name)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public List<String> Ingredients { get; set; }
        public MedicineStatus MedicineStatus
        {
            get { return _MedicineStatus; }
            set
            {
                if (value != _MedicineStatus)
                {
                    _MedicineStatus = value;
                    OnPropertyChanged("MedicineStatus");
                }

            }
        }

        public int Quantity
        {
            get { return _Quantity; }

            set
            {
                if (value != _Quantity)
                {
                    _Quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public Medicine(string name, List<string> ingredients, int quantity)
        {
            Name = name;
            Ingredients = ingredients;
            Quantity = quantity;
        }

        public Medicine(string name, List<string> ingredients, MedicineStatus medicineStatus, int quantity) : this(name, ingredients, quantity)
        {
            MedicineStatus = medicineStatus;
        }

        public string[] toCSV()
        {
            string[] csvValues = new string[Ingredients.Count + 3];

            csvValues[0] = Name;
            csvValues[1] = Quantity.ToString();
            csvValues[2] = MedicineStatus.ToString();


            int i = 3;
            foreach (String s in Ingredients)
            {
                csvValues[i] = s;
                int v = i++;
            }

            return csvValues;

        }

        public void fromCSV(string[] values)
        {
            if (values[0].Equals(""))
            {
                return;
            }
            Name = values[0];
            Quantity = int.Parse(values[1]);
            MedicineStatus = (MedicineStatus)Enum.Parse(typeof(MedicineStatus), values[2]);


            Ingredients = new List<String>();
            for (int i = 3; i < values.Length; i++)
            {
                Ingredients.Add(values[i]);
            }
        }

        public Medicine() { }
    }
}