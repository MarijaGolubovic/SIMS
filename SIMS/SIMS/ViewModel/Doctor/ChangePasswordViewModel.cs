using GalaSoft.MvvmLight.Messaging;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class ChangePasswordViewModel: BindableBase
    {
        public MyICommand ChangePasswordCommand { get; set; }
        public MyICommand CancelCommand { get; set; }
        public ChangePassword changePassword;

        public ChangePassword ChangePassword
        {
            get { return changePassword; }
            set
            {
                if (changePassword != value)
                {
                    changePassword = value;
                    OnPropertyChanged("changePassword");
                }
            }
        }
        public ChangePasswordViewModel()
        {
            changePassword = new ChangePassword();
            ChangePasswordCommand = new MyICommand(OnChange);
            CancelCommand = new MyICommand(OnCancel);
        }

        private void OnCancel()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
        private void OnChange()
        {
            ChangePassword.Validate();
            if (ChangePassword.IsValid) 
            {
                Messenger.Default.Send("AccountView");
                MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
            }
            
        }
    }
}
