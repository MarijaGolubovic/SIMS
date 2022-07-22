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
    class DeletePoll:ViewModel
    {
        private NavigationService navService;

        private Model.Polls poll;
        public Injector Inject { get; set; }

        public Model.Polls Poll
        {
            get { return poll; }
            set
            {
                poll = value;
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
            new Uri("View/DeletePoll.xaml", UriKind.Relative));

        }

        private ObservableCollection<Polls> polls;
        public RelayCommand DeletePollCommand { get; set; }

        public bool CanExecute_PollCommand(object obj)
        {
            return true;
        }

        public ObservableCollection<Polls> Polls
        {
            get { return polls; }
            set
            {
                polls = value;
                OnPropertyChanged();
            }
        }

        public DeletePoll(NavigationService navService, Model.Polls poll, Injector inject, RelayCommand deletePollCommand, ObservableCollection<Polls> polls)
        {
            this.navService = navService;
            Poll = poll;
            Inject = inject;
            DeletePollCommand = deletePollCommand;
            Polls = polls;
        }
    }
}
