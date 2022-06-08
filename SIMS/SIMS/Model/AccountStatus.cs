using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

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