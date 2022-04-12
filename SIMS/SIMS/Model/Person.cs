using System;

namespace SIMS.Model
{
   public class Person
   {

      public String Name { get; set; }
        public String Surname { get; set; }
        public String JMBG { get; set; }
        public String Telephone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String EMail { get; set; }

        public Address Address { get; set; }

        public Person(string name, string surname, string jMBG, string telephone, DateTime dateOfBirth, string eMail, Address address)
        {
            Name = name;
            Surname = surname;
            JMBG = jMBG;
            Telephone = telephone;
            DateOfBirth = dateOfBirth;
            EMail = eMail;
            Address = address;
        }
    }
}