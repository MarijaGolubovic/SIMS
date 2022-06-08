using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SIMS.Model
{
    public class Person : ValidationBase
    {

        public String Name { get; set; }
        public String Surname { get; set; }
        public String JMBG { get; set; }
        public String telephone;
        public DateTime DateOfBirth { get; set; }
        public String eMail;
        public Address address;

        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (telephone != value)
                {
                    telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }
        public Address Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        public string EMail
        {
            get { return eMail; }
            set
            {
                if (eMail != value)
                {
                    eMail = value;
                    OnPropertyChanged("EMail");
                }
            }
        }

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

        public Person(string name, string surname, string jMBG, string telephone, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            JMBG = jMBG;
            Telephone = telephone;
            DateOfBirth = dateOfBirth;
            Address = new Address("", "", new City(), new Country());
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.telephone))
            {
                this.ValidationErrors["Telephone"] = "Telefon ne smije biti prazan!";
            }
            else if (this.telephone.Length != 10)
            {
                this.ValidationErrors["Telephone"] = "Telefon mora sadržati 10 cifara!";
            }
            else if (!Regex.IsMatch(this.telephone, @"^\d+$"))
            {
                this.ValidationErrors["Telephone"] = "Dozvoljeni su samo brojevi!";
            }

            if (string.IsNullOrWhiteSpace(this.eMail))
            {
                this.ValidationErrors["EMail"] = "E-mail ne smije biti prazan!";
            }
            else if (!Regex.IsMatch(this.eMail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                this.ValidationErrors["EMail"] = "Format e-maila nije dobar!";
            }
            address.Validate();
            if (!address.IsValid)
            {
                this.ValidationErrors["Adresa"] = "Adresa nije dobra!";
            }
        }
    }
}