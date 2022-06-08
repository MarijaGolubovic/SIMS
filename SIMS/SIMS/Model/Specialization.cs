using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{

    public class Specialization : Serialization.Serializable
    {
        public String Name { get; set; }

        public Specialization(string name)
        {
            Name = name;
        }

        public Specialization()
        {
        }

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
    }
}