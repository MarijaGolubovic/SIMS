using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Service;
using SIMS.Model;

namespace SIMS.Controller
{
    class PollsController
    {
        private PollsService pollsService = new PollsService();

        public List<Polls> GetAll()
        {
            return pollsService.GetAll();
        }
    }
}
