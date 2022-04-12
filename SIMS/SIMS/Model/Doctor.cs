using System;

namespace SIMS.Model
{
   public class Doctor : User
   {
        public Specialization Specialization { get; set; }

        public Doctor(User user, Specialization specialization) : base(user.Username, user.Password, user.Type, user.Person)
        {
            this.Specialization = specialization;
        }

    }
}