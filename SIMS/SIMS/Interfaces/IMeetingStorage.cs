using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface IMeetingStorage
    {
        public List<Meeting> GetAll();
        public Boolean Create(Meeting meeting);
    }
}
