using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IDiagnosisStorage
    {
        public List<Diagnosis> GetAll();
        public Diagnosis GetOne(int appointmentID);
        public Boolean Delete(int appointmentID);
        public Boolean Create(Diagnosis diagnosisForAdd);
        public Boolean Update(Appointment appointment);
    }
}
