using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Controller;

namespace SIMS.Model
{
    public class Answers : Serialization.Serializable
    {
        public int ID { get; set; }
        public Question Question { get; set; }
        public int Answer { get; set; }
        private readonly QuestionController questionController = new QuestionController();

        public Answers()
        {
        }
        public Answers(Question question, int answer)
        {
            ID = 0;
            Question = question;
            Answer = answer;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                ID.ToString(),
                Question.ID.ToString(),
                Answer.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            ID = int.Parse(values[0]);
            Question = questionController.GetQuestionByID(int.Parse(values[1]));
            Answer = int.Parse(values[2]);
        }
    }
}
