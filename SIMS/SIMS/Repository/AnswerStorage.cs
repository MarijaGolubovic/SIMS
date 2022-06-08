using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SIMS.Repository
{
    public class AnswerStorage : IAnswerStorage
    {
        public AnswerStorage()
        {
        }

        public bool Create(Answers answer)
        {
            Serialization.Serializer<Answers> answerSerializer = new Serialization.Serializer<Answers>();
            List<Answers> answers = new List<Answers>();
            foreach (Answers a in answerSerializer.fromCSV("answers.txt"))
            {
                answers.Add(a);
            }
            answers.Add(answer);
            answerSerializer.toCSV("answers.txt", answers);
            return true;
        }
    }
}
