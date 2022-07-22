using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
 

namespace SIMS.ViewModel.Menager
{
    class MainTutorila:ViewModel
    {
        private NavigationService navService;
        public Injector Inject { get; set; }
        public MainTutorila mainTutorila;

      
        public MainTutorila MainTutorial
        {
            get { return mainTutorila; }
            set
            {
                mainTutorila = value;
                OnPropertyChanged();
            }
        }

        public void Executed_AddRoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/AddRoomTutorial.xaml", UriKind.Relative));
        }

        public void Executed_DeleteRoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DeleteRoomTutorial.xaml", UriKind.Relative));
        }

        public void Executed_EditRoomCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/EditRoomTutorial.xaml", UriKind.Relative));
        }

        public void Executed_EditMedicineCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/EditMedicineTutorial.xaml", UriKind.Relative));
        }
        public void Executed_DeleteMedicineCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DeleteMedicineTutorial.xaml", UriKind.Relative));
        }

        public void Executed_AddMedicineCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/AddMedicineTutorial.xaml", UriKind.Relative));
        }

        public void Executed_AddPollCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/AddPollTutorial.xaml", UriKind.Relative));
        }
        public void Executed_DeletePollCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DeletePollTutorial.xaml", UriKind.Relative));
        }

        public void Executed_DistributeEquipmentCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/DistributeEquipmentTutorial.xaml", UriKind.Relative));
        }

        public void Executed_OrderingEquipmentCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/OrderingEquipmentTutorial.xaml", UriKind.Relative));
        }

        public void Executed_MoveEquipmentCommand(object obj)
        {
            this.navService.Navigate(
            new Uri("View/MoveEqupmentTutorial.xaml", UriKind.Relative));
        }

        public MainTutorila(Injector inject, MainTutorila mainTutorial)
        {
            Inject = inject;
            MainTutorial = mainTutorial;
        }
    }
}
