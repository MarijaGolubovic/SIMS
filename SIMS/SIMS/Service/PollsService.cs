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

        public double CalculateAverage(Polls pollsItem)
        {
            double sum = 0;
            double numberOfGrade = 0;
            sum = pollsItem.One + pollsItem.Two * 2 + pollsItem.Three * 3 + pollsItem.Four * 4 + pollsItem.Fift * 5;
            numberOfGrade = pollsItem.One + pollsItem.Two + pollsItem.Three+ pollsItem.Four+ pollsItem.Fift;
            
            return Math.Round( sum/numberOfGrade,2);
        }

        public void SetAverage()
        {
            List<Polls> polls = GetAll();
            List<Polls> countedAverage = new List<Polls>();

            Serialization.Serializer<Polls> pollsSerijalization = new Serialization.Serializer<Polls>();
            foreach (Polls pollItem in polls)
            {
                pollItem.Average = CalculateAverage(pollItem);
                countedAverage.Add(pollItem);
            }
            pollsSerijalization.toCSV("Polls.txt",  countedAverage);
        }

        public PollsService()
        {
        }
    }
}
