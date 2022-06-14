using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Polls : INotifyPropertyChanged, Serialization.Serializable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

       

        public void fromCSV(string[] values)
        {
            JMBG = values[0];
            One = int.Parse(values[1]);
            Two = int.Parse(values[2]);
            Three = int.Parse(values[3]);
            Four = int.Parse(values[4]);
            Fift = int.Parse(values[5]);
            Average = double.Parse(values[6]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
                 {
                JMBG,
                One.ToString(),
                Two.ToString(),
                Three.ToString(),
                Four.ToString(),
                Fift.ToString(),
                Average.ToString()
            };
            return csvValues;
        }


        public string JMBG
        {
            get
            { return _JMBG; }

            set
            {
                if (value != _JMBG)
                {
                    _JMBG = value;
                    OnPropertyChanged("JMBG");
                }
            }
        }
        public int One
        {
            get
            { return _One; }

            set
            {
                if (value != _One)
                {
                    _One = value;
                    OnPropertyChanged("One");
                }
            }
        }
        public int Two
        {
            get
            { return _Two; }

            set
            {
                if (value != _Two)
                {
                    _Two = value;
                    OnPropertyChanged("Two");
                }
            }
        }
        public int Three
        {
            get
            { return _Three; }

            set
            {
                if (value != _Three)
                {
                    _Three = value;
                    OnPropertyChanged("Three");
                }
            }
        }
        public int Four
        {
            get
            { return _Four; }

            set
            {
                if (value != _Four)
                {
                    _Four = value;
                    OnPropertyChanged("Four");
                }
            }
        }
        public int Fift
        {
            get
            { return _Fift; }

            set
            {
                if (value != _Fift)
                {
                    _Fift = value;
                    OnPropertyChanged("Fift");
                }
            }
        }
        public double Average
        {
            get
            { return _Average; }

            set
            {
                if (value != _Average)
                {
                    _Average = value;
                    OnPropertyChanged("Average");
                }
            }
        }


        string _JMBG;
        int _One;
        int _Two;
        int _Three;
        int _Four;
        int _Fift;
        double _Average;

    }
}
