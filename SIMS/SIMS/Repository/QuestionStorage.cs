using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model;

namespace SIMS.Repository
{
    public class QuestionStorage
    {
        public QuestionStorage()
        {

        }

        public static List<Question> GetAll()
        {
            Serialization.Serializer<Question> questionSerializer = new Serialization.Serializer<Question>();
            List<Question> questions = questionSerializer.fromCSV("questions.txt");

            return questions;
        }

        public Question GetQuestionByID(int id)
        {
            Serialization.Serializer<Question> questionSerializer = new Serialization.Serializer<Question>();
            List<Question> questions = questionSerializer.fromCSV("questions.txt");
            Question question = new Question();

            foreach (Question q in questions)
            {
                if (q.ID == id)
                {
                    question = q;
                    break;
                }
            }
            return question;
        }
    }
}
