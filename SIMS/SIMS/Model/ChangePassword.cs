using SIMS.ViewModel.Doctor;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;



//klasa koju sam dodao radi validacije koja mora pratiti mvvm sablon

namespace SIMS.Model
{
    internal class ChangePassword : ValidationBase
    {
        public String oldPassword;
        public String newPassword;
        public String repeatedNewPassword;

        public string OldPassword
        {
            get { return oldPassword; }
            set
            {
                if (oldPassword != value)
                {
                    oldPassword = value;
                    OnPropertyChanged("oldPassword");
                }
            }
        }
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                if (newPassword != value)
                {
                    newPassword = value;
                    OnPropertyChanged("newPassword");
                }
            }
        }
        public string RepeatedNewPassword
        {
            get { return repeatedNewPassword; }
            set
            {
                if (repeatedNewPassword != value)
                {
                    repeatedNewPassword = value;
                    OnPropertyChanged("repeatedNewPassword");
                }
            }
        }

        public ChangePassword()
        {
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.oldPassword))
            {
                this.ValidationErrors["OldPassword"] = "Stara lozinka ne smije biti prazna!";
            }
            else if (!this.oldPassword.Equals(MainWindowViewModel.LoggedInUser.Password))
            {
                this.ValidationErrors["OldPassword"] = "Niste unijeli ispravnu lozinku!";
            }

            if (string.IsNullOrWhiteSpace(this.newPassword))
            {
                this.ValidationErrors["NewPassword"] = "Nova lozinka ne smije biti prazna!";
            }

            if (string.IsNullOrWhiteSpace(this.repeatedNewPassword))
            {
                this.ValidationErrors["repeatedNewPassword"] = "Nova lozinka ne smije biti prazna!";
            }

            if (!this.newPassword.Equals(this.repeatedNewPassword))
            {
                this.ValidationErrors["repeatedNewPassword"] = "Ponovljena lozinka se ne podudara sa novom lozinkom!";
            }
        }
    }
}
