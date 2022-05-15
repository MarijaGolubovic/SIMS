using GalaSoft.MvvmLight.Messaging;
using SIMS.Controller;
using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Doctor
{
    internal class MedicineValidationViewModel:BindableBase
    {
        public MyICommand ValidateCommand { get; set; }
        public List<Medicine> Medicines { get; set; }
        private Medicine selectedMedicine;
        
        private readonly MedicineContoller medicineContoller = new MedicineContoller();
        public Medicine SelectedMedicine
        {
            get { return selectedMedicine; }
            set
            {
                selectedMedicine = value;
                ValidateCommand.RaiseCanExecuteChanged();
            }
        }
        public readonly MedicineContoller medicineController = new MedicineContoller();
        public MedicineValidationViewModel()
        {
            Medicines = medicineController.GetAllWithStatusOnHold();
            ValidateCommand = new MyICommand(OnValidate, CanValidate);
        }

        private void OnValidate()
        {
            medicineContoller.ChangeMedicineStatus(SelectedMedicine);
            Messenger.Default.Send("MedicineValidateView");
        }

        private bool CanValidate()
        {
            return SelectedMedicine != null;
        }
    }
}
