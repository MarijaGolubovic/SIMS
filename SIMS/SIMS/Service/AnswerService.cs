using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;

namespace SIMS.Service
{
    public class AnswerService
    {
        private IAnswerStorage answerStorage;

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
