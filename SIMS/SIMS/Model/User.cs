using System;

namespace SIMS.Model
{
   public class User
   {
        public String Username { get; set; }
        public String Password { get; set; }
        public UserType Type { get; set; }

        public Person Person { get; set; }

        public User(string username, string password, UserType type, Person person)
        {
            Username = username;
            Password = password;
            Type = type;
            Person = person;
        }

        public void fromCSV(string[] values)
        {
            Username = values[0];
            Password = values[1];
            Type = (UserType)int.Parse(values[2]);
            Person = new Person(values[3], values[4], values[5], values[6], DateTime.Parse(values[7]), values[8], null); //Adresa
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
                null    //ispraviti
            };
            return csvValues;
        }

    }
}