using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Repository;
using SIMS.Model;

namespace SIMS.Service
{
    public class AnswerService
    {
        private AnswerStorage answerStorage;

        public AnswerService()
        {
            answerStorage = new AnswerStorage();
        }

        public bool Create(Answers answer)
        {
            return answerStorage.Create(answer);
        }
    }
}
