using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;

namespace SIMS.Repository
{
    class PollsStorage
    {
        public List<Polls> GetAll()
        {
            List<Polls> polls = new List<Polls>();
            Serialization.Serializer<Polls> pollsSerijalization = new Serialization.Serializer<Polls>();
            polls = pollsSerijalization.fromCSV("Polls.txt");

            return polls;
        }
    }
}
