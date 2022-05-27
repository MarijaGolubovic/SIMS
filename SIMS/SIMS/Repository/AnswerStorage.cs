using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;

namespace SIMS.Repository
{
    public class AnswerStorage
    {
        public AnswerStorage()
        {
        }

        public bool Create(Answers answer)
        {
            Serialization.Serializer<Answers> answerSerializer = new Serialization.Serializer<Answers>();
            List<Answers> answers = new List<Answers>();
            foreach(Answers a in answerSerializer.fromCSV("answers.txt"))
            {
                answers.Add(a);
            }
            answers.Add(answer);
            answerSerializer.toCSV("answers.txt", answers);
            return true;
        }
    }
}
