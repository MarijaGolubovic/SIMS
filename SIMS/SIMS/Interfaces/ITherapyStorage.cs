using SIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Interfaces
{
    internal interface ITherapyStorage
    {
        public List<Therapy> GetAll();
        public List<Therapy> GetById(String id);
        public Boolean Create(Therapy therapy)
    }
}
