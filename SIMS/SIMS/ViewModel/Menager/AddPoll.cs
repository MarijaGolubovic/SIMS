using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Menager
{
    class Polls:ViewModel
    {
        private string name;
        private ObservableCollection<Polls> polls;
        public Injector Inject { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Polls> Poll
        {
            get { return polls; }
            set
            {
                polls = value;
                OnPropertyChanged();
            }
        }

        public Polls(Injector inject, string name, ObservableCollection<Polls> polls)
        {
            Inject = inject;
            Name = name;
            Poll = polls;
        }
    }
}
