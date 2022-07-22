using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Menager
{
    class ClassesPageViewModel
    {
        public Injector Inject { get; set; }

        public ObservableCollection<Model.Room> Rooms { get; set; }

        public ClassesPageViewModel(Injector inject, ObservableCollection<Room> rooms)
        {
            Inject = inject;
            Rooms = rooms;
        }
    }
}
