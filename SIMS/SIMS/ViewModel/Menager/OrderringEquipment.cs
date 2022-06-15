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
    class OrderringEquipment:ViewModel
    {
        private NavigationService navService;
        private Equpment equpments;
        private string name;
        private int quntity;
        public Injector Inject { get; set; }

        public Model.Equpment Equpment

        {
            get { return equpments; }
            set
            {
                equpments = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return quntity; }
            set
            {
                quntity = value;
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
            new Uri("View/OrderingEquipment.xaml", UriKind.Relative));

        }
        public RelayCommand OrderingEquipmentCommand { get; set; }

        public bool CanExecuteEquipmentCommand(object obj)
        {
            return true;
        }
        private ObservableCollection<Equpment> equipments;

        public ObservableCollection<Equpment> Equipment
        {
            get { return equipments; }
            set
            {
                equipments = value;
                OnPropertyChanged();
            }
        }

        public OrderringEquipment(NavigationService navService, Injector inject, Equpment equpment, string name, int quantity, RelayCommand orderingEquipmentCommand, ObservableCollection<Equpment> equipment)
        {
            this.navService = navService;
            Inject = inject;
            Equpment = equpment;
            Name = name;
            Quantity = quantity;
            OrderingEquipmentCommand = orderingEquipmentCommand;
            Equipment = equipment;
        }
    }
}
