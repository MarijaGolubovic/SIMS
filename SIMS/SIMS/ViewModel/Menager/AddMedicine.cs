using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using SIMS.Model;

namespace SIMS.ViewModel.Menager
{
    class AddMedicine
    {
        private Medicine medicine;
        private NavigationService navService;

        public Injector Inject { get; set; }

        public Medicine Medicine
        {
            get { return medicine; }
            set
            {
                medicine = value;
                OnPropertyChanged();
            }
        }

        public void Executed_RoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("Views/AddMedicine.xaml", UriKind.Relative));
            //NavigationCommands.BrowseBack.Execute;
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public RelayCommand AddMedicineCommand { get; set; }

        public bool CanExecute_AddMedicineCommand(object obj)
        {
            return true;
        }

        public AddMedicine(Medicine medicine, NavigationService navService, Injector inject, RelayCommand addMedicineCommand)
        {
            Medicine = medicine;
            this.navService = navService;
            Inject = inject;
            AddMedicineCommand = addMedicineCommand;
        }
    }
}
