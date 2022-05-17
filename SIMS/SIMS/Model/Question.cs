using SIMS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model
{
    public class Question : Serialization.Serializable
    {
        public ReportID ReportID { get; set; }
        public CategoryID CategoryID { get; set; }
        public string QuestionText { get; set; }

        public Doctor Doctor { get; set; }
        public int ID { get; set; }

        private readonly DoctorController doctorController = new DoctorController();

        public Question(ReportID reportID, CategoryID categoryID, string questionText, Doctor doctor, int iD)
        {
            ReportID = reportID;
            CategoryID = categoryID;
            QuestionText = questionText;
            Doctor = doctor;
            ID = iD;
        }

        public Question()
        {

        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                ReportID.ToString(),
                CategoryID.ToString(),
                QuestionText,
                Doctor.Person.JMBG,
                ID.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            if (values[0] == "")
                return;
            ReportID = (ReportID)Enum.Parse(typeof(ReportID), values[0]);
            CategoryID = (CategoryID)Enum.Parse(typeof(CategoryID), values[1]);
            QuestionText = values[2];
            if (values[3] != null)
            {
                Doctor = doctorController.GetByID(values[3]);
            }
            ID = int.Parse(values[4]);
        }

        public override string ToString()
        {
            return QuestionText.ToString();
        }
    }
}
