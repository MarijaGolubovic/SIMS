using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    class RoomEqupment : Serialization.Serializable
    {

        private readonly Controller.EquipmentController equipmentController = new Controller.EquipmentController();

        public String RoomId { get; set; }
        public List<Equpment> roomEquipment { get; set; }

        String _RoomId;
        List<Equpment> _RoomEquipment { get; set; }

        public string[] toCSV()
        {
            string[] csvValues = {RoomId};
            int i = 1;
            foreach (Equpment equipment in roomEquipment) {
                csvValues[i] = equipment.ToString();
                i++;
            }

            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            RoomId = values[0];
            
            if (values == null)
                return;

            int i;
            for(i = 1; i < values.Length; i++){
                roomEquipment.Add(((Equpment)values[i]));
            }
            
        }

        public RoomEqupment(string roomId, List<Equpment> roomEquipment)
        {
            RoomId = roomId;
            this.roomEquipment = roomEquipment;
        }

        public RoomEqupment()
        {
        }

        public static explicit operator RoomEqupment(List<Equpment> v)
        {
            throw new NotImplementedException();
        }
    }
}
