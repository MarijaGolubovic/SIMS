using System;

namespace SIMS.Model
{
    public class AccountStatus
    {
        public Boolean initialAccount { get; set; }
        public Boolean activatedAccount { get; set; }

        public AccountStatus(bool initialAccount, bool activatedAccount)
        {
            this.initialAccount = initialAccount;
            this.activatedAccount = activatedAccount;
        }
    }
}