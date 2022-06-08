using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Model
{

    public class User : ValidationBase, Serialization.Serializable
    {

        public String username;
        public String password;
        public UserType Type { get; set; }

        public Person person;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public Person Person
        {
            get { return person; }
            set
            {
                if (person != value)
                {
                    person = value;
                    OnPropertyChanged("Person");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
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

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Korisnièko ime ne smije biti prazno!";
            }
            else if (this.Username.Length < 8)
            {
                this.ValidationErrors["Username"] = "Korisnièko ime mora imati više od 8 karaktera!";
            }

            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Lozinka ne smije biti prazna!";
            }
            person.Validate();
            if (!person.IsValid)
            {
                this.ValidationErrors["Person"] = "Osoba nije dobra!";
            }
        }

        public User()
        {
        }

        public Boolean CheckUser(User user)
        {
            return Person.JMBG.Equals(user.Person.JMBG);
        }

        public Boolean CheckPassword(String password)
        {
            return Password.Equals(password);
        }
        public Boolean CheckJMBG(String jmbg)
        {
            return Person.JMBG.Equals(jmbg);
        }


    }
}