using System;

namespace SIMS.Model
{
   public class AccountStatus
   {
      public Boolean initialAccount;
      public Boolean activatedAccount;

        public AccountStatus(bool initialAccount, bool activatedAccount)
        {
            this.initialAccount = initialAccount;
            this.activatedAccount = activatedAccount;
        }

    }
}