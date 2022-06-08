using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;

namespace SIMS.Model
{
    public class Patient : User, Serialization.Serializable
    {
        public MedicalRecord MedicalRecord { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public String Date { get; set; }
        public String JMBGP { get; set; }
        public Boolean InitialAccount { get; set; }
        public Boolean ActivatedAccount { get; set; }
        public int OffenceCounter { get; set; }

        public System.Threading.Timer _timer;

        public List<Notificatoin> NotificationList { get; set; }
        public Patient(User user, MedicalRecord medicalRecord, AccountStatus accountStatus) : base(user.Username, user.Password, user.Type, user.Person)
        {

            this.MedicalRecord = medicalRecord;
            this.AccountStatus = accountStatus;
            this.JMBGP = Person.JMBG;
            this.InitialAccount = accountStatus.initialAccount;
            this.ActivatedAccount = accountStatus.activatedAccount;
            this.NotificationList = new List<Notificatoin>();
            this.Date = Person.DateOfBirth.ToString().Split(' ')[0];
        }

        public Patient(User user, MedicalRecord medicalRecord, AccountStatus accountStatus, int offenceCounter) : base(user.Username, user.Password, user.Type, user.Person)
        {

            this.MedicalRecord = medicalRecord;
            this.AccountStatus = accountStatus;
            this.JMBGP = Person.JMBG;
            this.InitialAccount = accountStatus.initialAccount;
            this.ActivatedAccount = accountStatus.activatedAccount;
            this.NotificationList = new List<Notificatoin>();
            this.OffenceCounter = offenceCounter;
            this.Date = Person.DateOfBirth.ToString().Split(' ')[0];
        }

        public void Start30DayTimer()
        {
            TimeSpan span = new TimeSpan(30, 0, 0, 0);
            TimeSpan disablePeriodic = new TimeSpan(0, 0, 0, 0, -1);
            _timer = new System.Threading.Timer(timer_TimerCallback, null,
                span, disablePeriodic);
        }

        public void timer_TimerCallback(object state)
        {
            this.OffenceCounter += 1;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OffenceCounter = 0;
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
            OffenceCounter = int.Parse(values[3]);


        }
        public string[] toCSV()
        {
            string[] csvValues =
            {
             JMBGP,
             InitialAccount.ToString(),
             ActivatedAccount.ToString(),
             OffenceCounter.ToString()

            };
            return csvValues;
        }

        public Patient(string jMBGP, bool initialAccount, bool activatedAccount)
        {
            JMBGP = jMBGP;
            InitialAccount = initialAccount;
            ActivatedAccount = activatedAccount;
        }

        public Patient(bool initialAccount, bool activatedAccount, int offenseAccount)
        {
            ActivatedAccount = activatedAccount;
            OffenceCounter = offenseAccount;
        }
    }
}
