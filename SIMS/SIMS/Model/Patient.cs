using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class Patient : User, Serialization.Serializable
    {
        public MedicalRecord MedicalRecord { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public String JMBGP { get; set; }
        public Boolean InitialAccount { get; set; }
        public Boolean ActivatedAccount { get; set; }

        public List<Notificatoin> NotificationList { get; set; }
        public Patient(User user, MedicalRecord medicalRecord, AccountStatus accountStatus) : base(user.Username, user.Password, user.Type, user.Person)
        {
            
            this.MedicalRecord = medicalRecord;
            this.AccountStatus = accountStatus;
            this.JMBGP = Person.JMBG;
            this.InitialAccount = accountStatus.initialAccount;
            this.ActivatedAccount = accountStatus.activatedAccount;
            this.NotificationList = new List<Notificatoin>();
        }
        public Patient()
        {
        }
        public void fromCSV(string[] values)

        {
            JMBGP = values[0];
            if (values[1].Contains("True"))
                InitialAccount = true;
            else
                InitialAccount = false;

            if (values[2].Contains("True"))
                ActivatedAccount = true;
            else
                ActivatedAccount = false;



        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
             JMBGP,
             InitialAccount.ToString(),
             ActivatedAccount.ToString()

            };
            return csvValues;
        }

        public Patient(string jMBGP, bool initialAccount, bool activatedAccount)
        {
            JMBGP = jMBGP;
            InitialAccount = initialAccount;
            ActivatedAccount = activatedAccount;
        }
    }
}
