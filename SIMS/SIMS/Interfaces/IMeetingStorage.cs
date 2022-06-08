using SIMS.Interfaces;
using SIMS.Model;
using System;
using System.Collections.Generic;

namespace SIMS.Interfaces
{
    internal interface IMeetingStorage
    {
        public List<Meeting> GetAll();
        public Boolean Create(Meeting meeting);
    }
}
