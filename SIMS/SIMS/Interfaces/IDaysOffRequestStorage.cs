using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

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
