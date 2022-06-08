using SIMS.Interfaces;
using SIMS.Model;
using SIMS.Repository;
using SIMS.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace SIMS.Service
{
    public class QuesttionService
    {
        private QuestionStorage questionStorage;

        public QuesttionService()
        {
            questionStorage = new QuestionStorage();
        }

        public List<Question> GetAll()
        {
            return QuestionStorage.GetAll();
        }

        public List<Question> GetHospitalQuestionsAbouHygiene()
        {
            List<Question> questions = QuestionStorage.GetAll();
            List<Question> questionsAboutHygiene = new List<Question>();
            foreach (Question q in questions)
            {
                if (q.ReportID.Equals(ReportID.HOSPITAL_REPORT) && q.CategoryID.Equals(CategoryID.HYGIENE))
                {
                    questionsAboutHygiene.Add(q);
                }
            }
            return questionsAboutHygiene;
        }

        public List<Question> GetHospitalQuestionsAbouStaff()
        {
            List<Question> questions = QuestionStorage.GetAll();
            List<Question> questionsAboutStaff = new List<Question>();
            foreach (Question q in questions)
            {
                if (q.ReportID.Equals(ReportID.HOSPITAL_REPORT) && q.CategoryID.Equals(CategoryID.STAFF))
                {
                    questionsAboutStaff.Add(q);
                }
            }
            return questionsAboutStaff;
        }

        public List<Question> GetDoctorQuestionsAbouApproach()
        {
            List<Question> questions = QuestionStorage.GetAll();
            List<Question> questionsAboutApproach = new List<Question>();
            foreach (Question q in questions)
            {
                if (q.ReportID.Equals(ReportID.DOCTOR_REPORT) && q.CategoryID.Equals(CategoryID.APPROACH))
                {
                    questionsAboutApproach.Add(q);
                }
            }
            return questionsAboutApproach;
        }
        public List<Question> GetDoctorQuestionsAbouProfessionalism()
        {
            List<Question> questions = QuestionStorage.GetAll();
            List<Question> questionsAboutProf = new List<Question>();
            foreach (Question q in questions)
            {
                if (q.ReportID.Equals(ReportID.DOCTOR_REPORT) && q.CategoryID.Equals(CategoryID.PROFESSIONALISM))
                {
                    questionsAboutProf.Add(q);
                }
            }
            return questionsAboutProf;
        }

        public Question GetQuestionByID(int id)
        {
            return questionStorage.GetQuestionByID(id);
        }

    }
}
