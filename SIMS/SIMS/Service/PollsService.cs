using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Repository;
using SIMS.Model;

namespace SIMS.Service
{
    class PollsService
    {
        private PollsStorage pollsStorage = new PollsStorage();
        public List<Polls> GetAll()
        {
            return pollsStorage.GetAll();
        }

        public PollsService()
        {
        }
    }
}
