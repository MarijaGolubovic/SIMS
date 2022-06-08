using SIMS.Controller;
using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;

namespace SIMS.Model
{
    public class Answers : Serialization.Serializable
    {
        public int ID { get; set; }
        public Question Question { get; set; }
        public int Answer { get; set; }
        public Doctor Doctor { get; set; }
        public string DoctorID { get; set; }

        private readonly QuestionController questionController = new QuestionController();
        private readonly DoctorController doctorController = new DoctorController();

        public Answers()
        {
        }
        public Answers(Question question, int answer, Doctor doctor)
        {
            ID = 0;
            Question = question;
            Answer = answer;
            Doctor = doctor;
            DoctorID = Doctor.Person.JMBG;
        }
        public Answers(Question question, int answer, string jmbg)
        {
            ID = 0;
            Question = question;
            Answer = answer;
            Doctor = doctorController.GetByID(jmbg);
            DoctorID = jmbg;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                ID.ToString(),
                Question.ID.ToString(),
                DoctorID,
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
            if (!values[2].Equals(""))
            {
                Doctor = doctorController.GetByID(values[2]);
                DoctorID = Doctor.Person.JMBG;
            }
            else
            {
                Doctor = null;
                DoctorID = "";
            }
            Answer = int.Parse(values[3]);
        }
    }
}
