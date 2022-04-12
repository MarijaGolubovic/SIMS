using System;

namespace SIMS.Model
{
    public class Patient : User, Serialization.Serializable
    {
        public MedicalRecord MedicalRecord { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public Patient(User user, MedicalRecord medicalRecord, AccountStatus accountStatus) : base(user.Username, user.Password, user.Type, user.Person)
        {
            this.MedicalRecord = medicalRecord;
            this.AccountStatus = accountStatus;
        }
        public Patient()
        {
        }
        public void fromCSV(string[] values)

        {
            Person.JMBG = values[0];
            Boolean InitialAccoun = false;
            Boolean ActivatedAccount = false;

            if (values[1].Contains("True"))
                InitialAccoun = true;
            if (values[2].Contains("True"))
                ActivatedAccount = true;
            new AccountStatus(InitialAccoun, ActivatedAccount);

        }
        public string[] toCSV()
        {
            string[] csvValues =
{
             Person.JMBG,
             AccountStatus.initialAccount.ToString(),
             AccountStatus.activatedAccount.ToString()

            };
            return csvValues;
        }
    }
}