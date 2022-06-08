using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System.Collections.ObjectModel;
using ToastNotifications.Messages;

namespace SIMS.ViewModel.Doctor
{
    internal class MedicineValidationViewModel : BindableBase
    {
        public MyICommand ValidateCommand { get; set; }
        public MyICommand SendToDirectorCommand { get; set; }
        public MyICommand FinishCommand { get; set; }
        public ObservableCollection<Medicine> Medicines { get; set; }
        private Medicine selectedMedicine;

        private readonly MedicineContoller medicineContoller = new MedicineContoller();
        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                ValidateCommand.RaiseCanExecuteChanged();
                SendToDirectorCommand.RaiseCanExecuteChanged();
            }
        }
        public readonly MedicineContoller medicineController = new MedicineContoller();
        public MedicineValidationViewModel()
        {
            Medicines = new ObservableCollection<Medicine>();
            foreach (Medicine medicine in medicineController.GetAllWithStatusOnHold())
            {
                Medicines.Add(medicine);
            }
            ValidateCommand = new MyICommand(OnValidate, CanValidate);
            SendToDirectorCommand = new MyICommand(OnSendToDirector, CanSendToDirector);
            FinishCommand = new MyICommand(OnFinish);
        }

        private void OnValidate()
        {
            medicineContoller.ChangeMedicineStatusOnValid(SelectedMedicine);
            Medicines.Remove(SelectedMedicine);
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }

        private bool CanValidate()
        {
            return SelectedMedicine != null;
        }

        private void OnSendToDirector()
        {
            medicineContoller.ChangeMedicineStatusOnInvalid(SelectedMedicine);
            Medicines.Remove(SelectedMedicine);
            MainWindowViewModel.notifier.ShowSuccess("Uspješno!");
        }
        private bool CanSendToDirector()
        {
            return SelectedMedicine != null;
        }

        private void OnFinish()
        {
            Messenger.Default.Send("AllAppointmentView");
        }
    }
}
