using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class Doctor : User, Serialization.Serializable
    {
        public Specialization Specialization { get; set; }
        public Doctor(User user, Specialization specialization) : base(user.Username, user.Password, user.Type, user.Person)
        {
            this.Specialization = specialization;
        }

        public Doctor() { }
        public string[] toCSV()
        {
            string[] csvValues =
            {
                Person.JMBG,
                Specialization.Name
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            Person.JMBG = values[0];
            Specialization.Name = values[1];
        }

        public override string ToString()
        {
            return Username;
        }
    }


}