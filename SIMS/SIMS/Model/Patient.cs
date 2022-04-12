using System;

namespace SIMS.Model
{
    public class Patient : User
    {
        public MedicalRecord medicalRecord;
        public AccountStatus accountStatus;

        public Patient(User user,MedicalRecord medicalRecord, AccountStatus accountStatus):base(user.Username,user.Password,user.Type,user.Person)
        {
            this.medicalRecord = medicalRecord;
            this.accountStatus = accountStatus;
        }
    }
}