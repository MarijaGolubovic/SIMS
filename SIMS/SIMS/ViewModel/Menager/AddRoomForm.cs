using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ViewModel.Menager
{
    class AddRoomForm:ViewModel
    {
        private string id;

        private string size;

        private Model.RoomType type;

        private ObservableCollection<AddRoom> rooms;

        public Injector Inject { get; set; }

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Size
        {
            get { return size; }
            set
            {
                size = value;
                OnPropertyChanged();
            }
        }

        public Model.RoomType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AddRoom> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public AddRoomForm()
        {
            Inject = new Injector();
        }
    }
}
