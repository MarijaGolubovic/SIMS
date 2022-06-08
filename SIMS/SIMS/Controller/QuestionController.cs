using SIMS.Model;
using SIMS.Service;
using System;
using System.Collections.Generic;


namespace SIMS.Controller
{
    public class QuestionController
    {
        private readonly QuesttionService questionService = new QuesttionService();

        public QuestionController()
        {
        }

        public List<Question> GetHospitalQuestionsAbouHygiene()
        {
            return questionService.GetHospitalQuestionsAbouHygiene();
        }

        public List<Question> GetHospitalQuestionsAbouStaff()
        {
            return questionService.GetHospitalQuestionsAbouStaff();
        }

        public List<Question> GetDoctorQuestionsAbouApproach()
        {
            return questionService.GetDoctorQuestionsAbouApproach();
        }

        public List<Question> GetDoctorQuestionsAbouProfessionalism()
        {
            return questionService.GetDoctorQuestionsAbouProfessionalism();
        }

        public Question GetQuestionByID(int id)
        {
            return questionService.GetQuestionByID(id);
        }

    }
}
