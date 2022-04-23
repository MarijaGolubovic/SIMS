using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Controller
{
    public class MedicineContoller
    {
        private MedicineService medicineService;

        public MedicineContoller() 
        {
            medicineService = new MedicineService();   
        }

        public List<Medicine> GetAll() 
        {
            return medicineService.GetAll();
        }

        public Medicine GetOne(string name)
        {
            return medicineService.GetOne(name);
        }
    }
}
