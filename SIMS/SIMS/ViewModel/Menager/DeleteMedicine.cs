using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using SIMS.Model;
namespace SIMS.ViewModel.Menager
{
    class DeleteMedicine:ViewModel
    {
        private NavigationService navService;
        private Medicine medicine;
        public Injector Inject { get; set; }
        public string name;
        public string igredisnts;
        public int quantity;

        public Model.Medicine Medicine
        {
            get { return medicine; }
            set
            {
                medicine = value;
                OnPropertyChanged();
            }
        }

        

        public string Naee
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Igredients
        {
            get { return igredisnts; }
            set
            {
                igredisnts = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }
        public void Executed_RoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DeleteMedicine.xaml", UriKind.Relative));

        }
        private ObservableCollection<Medicine> medicines;
        public RelayCommand DeleteRoomCommand { get; set; }

        public bool CanExecute_MedicineCommand(object obj)
        {
            return true;
        }

        public ObservableCollection<Medicine> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                OnPropertyChanged();
            }
        }

        public DeleteMedicine(NavigationService navService, Injector inject, Medicine medicine, string naee, string igredients, int quantity, RelayCommand deletePollCommand, ObservableCollection<Medicine> medicines)
        {
            this.navService = navService;
            Inject = inject;
            Medicine = medicine;
            Naee = naee;
            Igredients = igredients;
            Quantity = quantity;
            DeleteRoomCommand = deletePollCommand;
            Medicines = medicines;
        }
    }
}
