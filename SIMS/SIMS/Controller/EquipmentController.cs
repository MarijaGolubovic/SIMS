using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    class EquipmentController
    {
        private Service.EquipmentService equipmentService = new Service.EquipmentService();

        public List<Model.Equpment> GetAll() {

            return equipmentService.GetAll();
        }
    }

}
