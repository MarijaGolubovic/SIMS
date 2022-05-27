using System.Collections.Generic;

namespace SIMS.Controller
{
    class EquipmentController
    {
        private Service.EquipmentService equipmentService = new Service.EquipmentService();

        public List<Model.Equpment> GetAll()
        {

            return equipmentService.GetAll();
        }


    }



}
