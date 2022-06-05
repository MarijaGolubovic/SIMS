using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IDaysOffRequestStorage
    {
        public List<DaysOffRequest> GetAll();
        public DaysOffRequest GetOne(int requestId);
        public void Create(DaysOffRequest request);
        public Boolean Update(DaysOffRequest daysOffRequest);
    }
}
