using System;
using System.ComponentModel;

namespace SIMS.Model
{

    public class User : Serialization.Serializable
    {

        public String Username { get; set; }
        public String Password { get; set; }
        public UserType Type { get; set; }

        public Person Person { get; set; }

        public User(string username, string password, UserType type, Person person)
        {
            this.Username = username;
            this.Password = password;
            Type = type;
            Person = person;
        }


        public void fromCSV(string[] values)
        {
            Username = values[0];
            Password = values[1];
            if (values[2].Contains("patient"))
                Type = UserType.patient;
            if (values[2].Contains("doctor"))
                Type = UserType.doctor;
            if (values[2].Contains("secretary"))
                Type = UserType.secretary;
            if (values[2].Contains("menager"))
                Type = UserType.menager;


            Person = new Person(values[3], values[4], values[5], values[6], DateTime.Parse(values[7]), values[8], new Address(values[9], values[10], new City(values[11]), new Country(values[12])));

        }

        public string[] toCSV()
        {
            string[] csvValues =

            {

                Username,
                Password,
                Type.ToString(),
                Person.Name,
                Person.Surname,
                Person.JMBG,
                Person.Telephone,
                Person.DateOfBirth.ToString(),
                Person.EMail,
                Person.Address.Street,
                Person.Address.Number,
                Person.Address.City.Name,
                Person.Address.Country.Name
            };
            return csvValues;
        }

        public User()
        {
        }


    }
}